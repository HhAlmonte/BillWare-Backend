using AutoMapper;
using BillWare.Application.Costumer.Entities;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Costumer.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Costumer.Handler
{
    public class GetCostumersPagedQuerHandler : IRequestHandler<GetCostumersPagedQuery, PaginationResult<CostumerResponse>>
    {
        private readonly IBaseCrudRepository<CostumerEntity> _costumerRepository;
        private readonly IMapper _mapper;

        public GetCostumersPagedQuerHandler(IBaseCrudRepository<CostumerEntity> costumerRepository, IMapper mapper)
        {
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<CostumerResponse>> Handle(GetCostumersPagedQuery request, CancellationToken cancellationToken)
        {
            var costumersRequest = await _costumerRepository.GetEntitiesPaged(request.PageIndex, request.PageSize);

            var costumersReponse = _mapper.Map<PaginationResult<CostumerResponse>>(costumersRequest);

            return costumersReponse;
        }
    }
}
