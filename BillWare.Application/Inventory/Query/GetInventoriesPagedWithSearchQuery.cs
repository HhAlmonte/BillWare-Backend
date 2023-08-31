﻿using BillWare.Application.Inventory.Models;
using MediatR;

namespace BillWare.Application.Inventory.Query
{
    public class GetInventoriesPagedWithSearchQuery : IRequest<PaginationResult<InventoryResponse>>
    {
        public string Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetInventoriesPagedWithSearchQuery(string search, int pageIndex, int pageSize)
        {
            Search = search;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
