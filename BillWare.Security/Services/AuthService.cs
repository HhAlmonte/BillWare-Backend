using BillWare.Application.Common.Models;
using BillWare.Application.Features.Security.Entities;
using BillWare.Application.Features.Security.Models;
using BillWare.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BillWare.Infrastructure.Security.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<UserIdentity> userManager, 
                           SignInManager<UserIdentity> signInManager, 
                           IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception($"El usuario con Email {request.Email} no existe");
            }

            var signInResponse = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            
            if (!signInResponse.Succeeded)
            {
                throw new Exception($"El usuario con Email {request.Email} no existe");
            }
            
            var token = await GenerateToken(user);

            var userRole = await _userManager.GetRolesAsync(user);

            var authResponse = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                UserName = user.UserName,
                Role = userRole.FirstOrDefault(),
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return authResponse;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            
            if (existingUser != null)
            {
                throw new Exception($"Existe un usuario con el correo: {existingUser.Email}");
            }

            var newUser = new UserIdentity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                EmailConfirmed = true,
                NumberId = request.NumberId,
                Address = request.Address,  
                CreatedAt = DateTime.Now,
                Role = request.Role
            };

            var isCreated = await _userManager.CreateAsync(newUser, request.Password);

            if (isCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, request.Role);

                return new RegistrationResponse
                {
                    UserId = newUser.Id,
                    Email = newUser.Email,
                    UserName = newUser.UserName,
                    Token = "El usuario debe iniciar sesión"
                };
            }

            throw new Exception($"No se pudo crear el usuario con el correo: {request.Email}");
        }

        private async Task<JwtSecurityToken> GenerateToken(UserIdentity user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }.Union(userClaims).Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                               issuer: _jwtSettings.Issuer,
                               audience: _jwtSettings.Audience,
                               claims: claims,
                               expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationInMinutes),
                               signingCredentials: signingCredentials
            );

            return jwtSecurityToken;
        }
    }
}
