﻿using MediatR;

namespace BillWare.Application.Security.Command
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public DeleteUserCommand(string id)
        {
            Id = id;
        }
    }
}