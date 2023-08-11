using BillWare.Application.User.Entities;
using BillWare.Application.User.Models;

namespace BillWare.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> SignIn(SingInModel singInModel);
        Task<UserEntity> SingUp(SignUpModel signUpModel);
    }
}
