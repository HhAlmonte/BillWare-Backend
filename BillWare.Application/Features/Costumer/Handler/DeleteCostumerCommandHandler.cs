using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Costumer.Command;
using BillWare.Application.Features.Costumer.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Costumer.Handler
{
    public class DeleteCostumerCommandHandler : IRequestHandler<DeleteCostumerCommand, bool>
    {
        private readonly IBaseCrudRepository<CostumerEntity> _costumerRepository;
        private readonly ILogger<DeleteCostumerCommandHandler> _logger;

        public DeleteCostumerCommandHandler(IBaseCrudRepository<CostumerEntity> costumerRepository,
                                            ILogger<DeleteCostumerCommandHandler> logger)
        {
            _logger = logger;
            _costumerRepository = costumerRepository;
        }

        public async Task<bool> Handle(DeleteCostumerCommand request, CancellationToken cancellationToken)
        {
            var costumerToDelete = await _costumerRepository.GetEntityByIdAsync(request.Id);

            if (costumerToDelete == null)
            {
                _logger.LogError($"{request.Id} cliente no existe en el sistema");
                throw new NotFoundException(nameof(CostumerEntity), request.Id);
            }

            var costumerDeleted = await _costumerRepository.DeleteEntityByIdAsync(costumerToDelete);

            _logger.LogInformation($"Se ha eliminado la entidad Costumer con Id: {costumerToDelete.Id}");

            return costumerDeleted;
        }
    }
}
