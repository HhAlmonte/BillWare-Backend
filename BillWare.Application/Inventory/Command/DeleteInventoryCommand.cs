﻿using MediatR;

namespace BillWare.Application.Inventory.Command
{
    public class DeleteInventoryCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteInventoryCommand(int id)
        {
            Id = id;
        }
    }
}
