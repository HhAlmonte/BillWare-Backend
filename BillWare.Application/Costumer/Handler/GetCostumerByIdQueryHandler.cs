using AutoMapper;
using BillWare.Application.Costumer.Entities;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Costumer.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Costumer.Handler
{
    public class GetCostumerByIdQueryHandler : IRequestHandler<GetCostumerByIdQuery, CostumerModel>
    {
        private readonly IBaseCrudRepository<CostumerEntity> _costumerRepository;
        private readonly IMapper _mapper;

        public GetCostumerByIdQueryHandler(IBaseCrudRepository<CostumerEntity> costumerRepository, IMapper mapper)
        {
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }

        public async Task<CostumerModel> Handle(GetCostumerByIdQuery request, CancellationToken cancellationToken)
        {
            var costumer = await _costumerRepository.Get(request.Id);

            if (costumer == null)
                throw new CrudOperationException("Costumer not found");

            return _mapper.Map<CostumerModel>(costumer);
        }
    }
}
