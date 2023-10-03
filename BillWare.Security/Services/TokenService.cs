using BillWare.Application.Contracts.Service;
using BillWare.Application.Features.Account.Models;
using BillWare.Identity.Models;
using BillWare.Security.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BillWare.Identity.Services
{
    public class TokenService : ITokenService
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly SecurityDbContext _securityDbContext;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public TokenService(UserManager<IdentityUser> userManager,
                           IOptions<JwtSettings> jwtSettings,
                           SecurityDbContext securityDbContext,
                           TokenValidationParameters tokenValidationParameters)
        {
            _tokenValidationParameters = tokenValidationParameters;
            _securityDbContext = securityDbContext;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<Tuple<string, string>> GenerateToken(IdentityUser user)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Key));

            var userClaims = await _userManager.GetClaimsAsync(user);

            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user!.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user!.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }.Union(userClaims).Union(roleClaims)),
                Expires = DateTime.UtcNow.Add(_jwtSettings.ExpireTime),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);

            var jwtToken = jwtSecurityTokenHandler.WriteToken(token);

            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                IsUsed = false,
                IsRevoked = false,
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                ExpireDate = DateTime.UtcNow.AddMonths(6),
                Token = $"{GenerateRandomTokenCharacter(35)}{Guid.NewGuid()}"
            };

            await _securityDbContext.RefreshTokens!.AddAsync(refreshToken);
            await _securityDbContext.SaveChangesAsync();

            return new Tuple<string, string>(jwtToken, refreshToken.Token);
        }

        public async Task<AuthResponse> RefreshToken(TokenRequest tokenRequest)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var tokenValidationParamsClone = _tokenValidationParameters.Clone();

            tokenValidationParamsClone.ValidateLifetime = false;

            try
            {
                // token validation format
                var tokenVerification = jwtTokenHandler.ValidateToken(tokenRequest.Token, tokenValidationParamsClone, out var validatedToken);


                // encryption validation
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if (!result)
                    {
                        return new AuthResponse
                        {
                            Success = false,
                            Errors = new List<string>
                            {
                                "El Token tiene errores de encriptación"
                            }
                        };
                    }
                }

                // date expiration validation
                var utcExpiryDate = long.Parse(tokenVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expiryDate = UnixTimeStamToDateTime(utcExpiryDate);

                if(expiryDate > DateTime.UtcNow)
                {
                    return new AuthResponse
                    {
                        Success = false,
                        Errors = new List<string>
                            {
                                "El Token ha expirado"
                            }
                    };
                }

                // refresh token exist validation

                var storedToken = await _securityDbContext.RefreshTokens!.FirstOrDefaultAsync(x => x.Token == tokenRequest.RefreshToken);

                if(storedToken is null)
                {
                    return new AuthResponse
                    {
                        Success = false,
                        Errors = new List<string>
                        {
                            "El token no existe"
                        }
                    };
                }

                // token was used validation

                if (storedToken.IsUsed)
                {
                    return new AuthResponse
                    {
                        Success = false,
                        Errors = new List<string>
                        {
                            "El token ya fue usado"
                        }
                    };
                }

                // token was revoked validation
                if (storedToken.IsRevoked)
                {
                    return new AuthResponse
                    {
                        Success = false,
                        Errors = new List<string>
                        {
                            "El token ya fue revocado"
                        }
                    };
                }

                // validar el id del token

                var jti = tokenVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

                if(storedToken.JwtId != jti)
                {
                    return new AuthResponse
                    {
                        Success = false,
                        Errors = new List<string>
                        {
                            "El token no concuerda con el valor inicial"
                        }
                    };
                }

                if(storedToken.ExpireDate < DateTime.UtcNow)
                {
                    return new AuthResponse
                    {
                        Success = false,
                        Errors = new List<string>
                        {
                            "El refresh token ha expirado"
                        }
                    };
                }

                storedToken.IsUsed = true;
                _securityDbContext.RefreshTokens!.Update(storedToken);
                await _securityDbContext.SaveChangesAsync();

                var user = await _userManager.FindByIdAsync(storedToken.UserId);

                var token = await GenerateToken(user);

                return new AuthResponse
                {
                    Id = user.Id,
                    Token = token.Item1,
                    Email = user.Email,
                    UserName = user.UserName,
                    RefreshToken = token.Item2,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("Lifetime validation failed. The token is expired"))
                {
                    return new AuthResponse
                    {
                        Success = false,
                        Errors = new List<string>
                        {
                            "El token ha expirado. Inicia sesión nuevamente"
                        }
                    };
                }
                else
                {
                    return new AuthResponse
                    {
                        Success = false,
                        Errors = new List<string>
                        {
                            "El token tiene errores. Inicia sesión nuevamente"
                        }
                    };
                }
            }
        }

        private DateTime UnixTimeStamToDateTime(long unixTimeStamp)
        {
            var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            dateTimeVal = dateTimeVal.AddSeconds(unixTimeStamp).ToUniversalTime();

            return dateTimeVal;
        }

        private string GenerateRandomTokenCharacter(int length)
        {
            var random = new Random();

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length).Select(x => x[random.Next(x.Length)]).ToArray());
        }
    }
}