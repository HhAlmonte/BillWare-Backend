﻿using BillWare.Application.Shared.Models;

namespace BillWare.Application.Category.Models
{
    public class CategoryResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}