using BillWare.Application.Category.Command;
using BillWare.Application.Category.Entities;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Category.Handler
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;

        public DeleteCategoryCommandHandler(IBaseCrudRepository<CategoryEntity> inventoryRepository)
        {
            _categoryRepository = inventoryRepository;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var action = await _categoryRepository.DeleteEntityByIdAsync(request.Id);

            return action;
        }
    }
}
