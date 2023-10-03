using AutoMapper;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Costumer.Command;
using BillWare.Application.Features.Costumer.Entities;
using BillWare.Application.Features.Costumer.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Costumer.Handler
{
    public class UpdateCostumerCommandHandler : IRequestHandler<UpdateCostumerCommand, CostumerResponse>
    {
        private readonly IBaseCrudRepository<CostumerEntity> _costumerRepository;
        private readonly ILogger<UpdateCostumerCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateCostumerCommandHandler(IBaseCrudRepository<CostumerEntity> costumerRepository,
                                            ILogger<UpdateCostumerCommandHandler> logger,
                                            IMapper mapper)
        {
            _logger = logger;
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }

        public async Task<CostumerResponse> Handle(UpdateCostumerCommand request, CancellationToken cancellationToken)
        {
            var costumerToUpdate = _mapper.Map<CostumerEntity>(request);

            var costumerFromDb = await _costumerRepository.GetEntityByIdAsync(costumerToUpdate.Id);

            if (costumerFromDb == null)
            {
                _logger.LogError($"Costumer with Id: {costumerToUpdate.Id}, hasn't been found in db.");
                throw new NotFoundException(nameof(CostumerEntity), costumerToUpdate.Id);
            }

            var costumerUpdated = await _costumerRepository.UpdateEntityAsync(costumerToUpdate);

            _logger.LogInformation($"Se ha actualizado la entidad Costumer con Id: {costumerUpdated.Id}");

            var costumerMapped = _mapper.Map<CostumerResponse>(costumerUpdated);

            return costumerMapped;
        }
    }
}
