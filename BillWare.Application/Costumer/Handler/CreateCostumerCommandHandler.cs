using AutoMapper;
using BillWare.Application.Costumer.Command;
using BillWare.Application.Costumer.Entities;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Costumer.Handler
{
    public class CreateCostumerCommandHandler : IRequestHandler<CreateCostumerCommand, CostumerResponse>
    {
        private readonly IBaseCrudRepository<CostumerEntity> _costumerRepository;
        private readonly IMapper _mapper;

        public CreateCostumerCommandHandler(IBaseCrudRepository<CostumerEntity> costumerRepository, IMapper mapper)
        {
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }

        public async Task<CostumerResponse> Handle(CreateCostumerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var costumerToCreate = _mapper.Map<CostumerEntity>(request.Request);

                var costumerRequest = await _costumerRepository.CreateEntityAsync(costumerToCreate);

                var costumerResponse = _mapper.Map<CostumerResponse>(costumerRequest);

                return costumerResponse;
            }
            catch (CrudOperationException ex)
            {
                throw new CrudOperationException(ex.Message);
            }
        }
    }
}
