using AutoMapper;
using BillWare.Application.Contracts;
using BillWare.Application.Features.Costumer.Entities;
using BillWare.Application.Features.Costumer.Models;
using BillWare.Application.Features.Costumer.Query;
using MediatR;

namespace BillWare.Application.Features.Costumer.Handler
{
    public class GetCostumersPagedWithSearchQueryHandler : IRequestHandler<GetCostumersPagedWithSearchQuery, PaginationResult<CostumerResponse>>
    {
        private readonly IBaseCrudRepository<CostumerEntity> _costumerRepository;
        private readonly IMapper _mapper;

        public GetCostumersPagedWithSearchQueryHandler(IBaseCrudRepository<CostumerEntity> costumerRepository, IMapper mapper)
        {
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<CostumerResponse>> Handle(GetCostumersPagedWithSearchQuery request, CancellationToken cancellationToken)
        {
            var costumerPaged = await _costumerRepository.GetEntitiesPagedWithSearch(request.Search, request.PageIndex, request.PageSize);

            var costumerPagedMapped = _mapper.Map<PaginationResult<CostumerResponse>>(costumerPaged);

            return costumerPagedMapped;
        }
    }
}
