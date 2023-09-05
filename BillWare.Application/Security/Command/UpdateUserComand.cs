using BillWare.Application.Security.Models;
using MediatR;

namespace BillWare.Application.Security.Command
{
    public class UpdateUserComand : IRequest<UserResponse>
    {
        public UpdateUserRequest Request { get; set; }

        public UpdateUserComand(UpdateUserRequest request)
        {
            Request = request;
        }
    }
}
