using BillWare.Application.Interfaces;
using BillWare.Application.User.Entities;
using BillWare.Application.User.Models;
using Microsoft.AspNetCore.Identity;

namespace BillWare.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public UserRepository(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserEntity> SignIn(SingInModel singInModel)
        {
            var user = await _userManager.FindByEmailAsync(singInModel.Email);

            if (user == null)
                throw new Exception("User not found");

            var result = await _signInManager.CheckPasswordSignInAsync(user, singInModel.Password, false);

            if (!result.Succeeded)
                throw new Exception("Password is incorrect");

            return user;
        }

        public async Task<UserEntity> SingUp(SignUpModel signUpModel)
        {
            var user = new UserEntity
            {
                Email = signUpModel.Email,
                UserName = signUpModel.UserName,
                FirstName = signUpModel.Name,
                LastName = signUpModel.LastName
            };

            var result = await _userManager.CreateAsync(user, signUpModel.Password);

            if (!result.Succeeded)
                throw new Exception("User not created");

            return user;
        }
    }
}
