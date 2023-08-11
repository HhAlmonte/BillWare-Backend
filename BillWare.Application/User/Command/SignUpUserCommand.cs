using BillWare.Application.User.Models;
using MediatR;

namespace BillWare.Application.User.Command
{
    public class SignUpUserCommand : IRequest<UserModel>
    {
        public SignUpUserCommand(SignUpModel signUpModel)
        {
            SignUpModel = signUpModel;
        }

        public SignUpModel SignUpModel { get; set; }
    }
}
