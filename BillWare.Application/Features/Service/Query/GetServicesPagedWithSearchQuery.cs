using BillWare.Application.Features.BillingService.Models;
using MediatR;

namespace BillWare.Application.Features.Service.Query
{
    public class GetServicesPagedWithSearchQuery : IRequest<PaginationResult<ServiceResponse>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Search { get; set; } = string.Empty;

    }
}
