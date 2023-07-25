using AutoMapper;
using BillWare.Application.Costumer.Command;
using BillWare.Application.Costumer.Entities;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Costumer.Handler
{
    public class UpdateCostumerCommandHandler : IRequestHandler<UpdateCostumerCommand, CostumerVM>
    {
        private readonly IBaseCrudRepository<CostumerEntity> _costumerRepository;
        private readonly IMapper _mapper;

        public UpdateCostumerCommandHandler(IBaseCrudRepository<CostumerEntity> costumerRepository, IMapper mapper)
        {
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }

        public async Task<CostumerVM> Handle(UpdateCostumerCommand request, CancellationToken cancellationToken)
        {
            var costumerToUpdate = _mapper.Map<CostumerEntity>(request.CostumerUpdate);

            var action = await _costumerRepository.Update(request.Id, costumerToUpdate);

            var costumerMapped = _mapper.Map<CostumerVM>(action);

            return costumerMapped;
        }
    }
}
