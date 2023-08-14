﻿using BillWare.Application.Inventory.Models;
using MediatR;

namespace BillWare.Application.Inventory.Query
{
    public class GetInventoriesPagedQuery : IRequest<PaginationResult<InventoryVM>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetInventoriesPagedQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}