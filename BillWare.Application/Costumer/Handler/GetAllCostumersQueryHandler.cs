using AutoMapper;
using BillWare.Application.Costumer.Entities;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Costumer.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Costumer.Handler
{
    public class GetAllCostumersQueryHandler : IRequestHandler<GetAllCostumersQuery, PaginationResult<CostumerVM>>
    {
        private readonly IBaseCrudRepository<CostumerEntity> _costumerRepository;
        private readonly IMapper _mapper;

        public GetAllCostumersQueryHandler(IBaseCrudRepository<CostumerEntity> costumerRepository, IMapper mapper)
        {
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<CostumerVM>> Handle(GetAllCostumersQuery request, CancellationToken cancellationToken)
        {
            var costumers = await _costumerRepository.Get(request.PageIndex, request.PageSize);

            var costumersMapped = _mapper.Map<PaginationResult<CostumerVM>>(costumers);

            return costumersMapped;
        }
    }
}
