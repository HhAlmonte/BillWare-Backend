using AutoMapper;
using BillWare.Application.Contracts;
using BillWare.Application.Features.Costumer.Entities;
using BillWare.Application.Features.Costumer.Models;
using BillWare.Application.Features.Costumer.Query;
using MediatR;

namespace BillWare.Application.Features.Costumer.Handler
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
            var costumersPaged = await _costumerRepository.GetEntitiesPaged(request.PageIndex, request.PageSize);

            var costumersPagedMapped = _mapper.Map<PaginationResult<CostumerResponse>>(costumersPaged);

            return costumersPagedMapped;
        }
    }
}
