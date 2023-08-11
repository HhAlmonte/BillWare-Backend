using BillWare.Application.User.Models;
using MediatR;

namespace BillWare.Application.User.Command
{
    public class SignInUserCommand : IRequest<UserModel>
    {
        public SignInUserCommand(SingInModel singInModel)
        {
            SingInModel = singInModel;
        }

        public SingInModel SingInModel { get; set; }
    }
}
