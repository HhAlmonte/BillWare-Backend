using AutoMapper;
using BillWare.Application.Costumer.Command;
using BillWare.Application.Costumer.Entities;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Costumer.Handler
{
    public class CreateCostumerCommandHandler : IRequestHandler<CreateCostumerCommand, CostumerVM>
    {
        private readonly IBaseCrudRepository<CostumerEntity> _costumerRepository;
        private readonly IMapper _mapper;

        public CreateCostumerCommandHandler(IBaseCrudRepository<CostumerEntity> costumerRepository, IMapper mapper)
        {
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }

        public async Task<CostumerVM> Handle(CreateCostumerCommand request, CancellationToken cancellationToken)
        {
            var costumerToCreate = _mapper.Map<CostumerEntity>(request.CostumerCreate);

            var result = await _costumerRepository.Create(costumerToCreate);

            return _mapper.Map<CostumerVM>(result);
        }
    }
}
