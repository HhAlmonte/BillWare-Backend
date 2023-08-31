using AutoMapper;
using BillWare.Application.Costumer.Entities;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Costumer.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Costumer.Handler
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
            var costumerRequest = await _costumerRepository.GetEntitiesPagedWithSearch(request.Search, request.PageIndex, request.PageSize);

            var costumerResponse = _mapper.Map<PaginationResult<CostumerResponse>>(costumerRequest);

            return costumerResponse;
        }
    }
}
