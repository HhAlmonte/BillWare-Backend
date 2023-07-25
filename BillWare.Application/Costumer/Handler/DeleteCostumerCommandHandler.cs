using BillWare.Application.Costumer.Command;
using BillWare.Application.Costumer.Entities;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Costumer.Handler
{
    public class DeleteCostumerCommandHandler : IRequestHandler<DeleteCostumerCommand, bool>
    {
        private readonly IBaseCrudRepository<CostumerEntity> _costumerRepository;

        public DeleteCostumerCommandHandler(IBaseCrudRepository<CostumerEntity> costumerRepository)
        {
            _costumerRepository = costumerRepository;
        }

        public async Task<bool> Handle(DeleteCostumerCommand request, CancellationToken cancellationToken)
        {
            var action = await _costumerRepository.Delete(request.Id);

            return action;
        }
    }
}
