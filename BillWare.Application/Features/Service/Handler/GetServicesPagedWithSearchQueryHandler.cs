using AutoMapper;
using BillWare.Application.Contracts;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.BillingService.Entities;
using BillWare.Application.Features.BillingService.Models;
using BillWare.Application.Features.Service.Query;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.BillingService.Handler
{
    public class GetServicesPagedWithSearchQueryHandler : IRequestHandler<GetServicesPagedWithSearchQuery, PaginationResult<ServiceResponse>>
    {
        private readonly IBaseCrudRepository<ServiceEntity> _billingServiceRepository;
        private readonly ILogger<GetServicesPagedWithSearchQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetServicesPagedWithSearchQueryHandler(IBaseCrudRepository<ServiceEntity> billingServiceRepository,
                                                      ILogger<GetServicesPagedWithSearchQueryHandler> logger,
                                                      IMapper mapper)
        {
            _billingServiceRepository = billingServiceRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PaginationResult<ServiceResponse>> Handle(GetServicesPagedWithSearchQuery request, CancellationToken cancellationToken)
        {
            var servicesPaged = await _billingServiceRepository.GetEntitiesPagedWithSearch(request.Search, request.PageIndex, request.PageSize);

            if (servicesPaged == null)
            {
                _logger.LogError($"No se encontraron servicios en el sistema");
                throw new NotFoundException(nameof(ServiceResponse), request.Search);
            }

            var servicesPagedMapped = _mapper.Map<PaginationResult<ServiceResponse>>(servicesPaged);

            return servicesPagedMapped;
        }
    }
}
