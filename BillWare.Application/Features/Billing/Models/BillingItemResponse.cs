﻿using BillWare.Application.Shared.Models;

namespace BillWare.Application.Features.Billing.Models
{
    public class BillingItemResponse : BaseResponse
    {
        public int Code { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal Amount { get; set; }
    }
}
