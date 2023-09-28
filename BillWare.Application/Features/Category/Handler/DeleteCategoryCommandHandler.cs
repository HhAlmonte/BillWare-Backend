using BillWare.Application.Contracts;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Category.Command;
using BillWare.Application.Features.Category.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Category.Handler
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;

        public DeleteCategoryCommandHandler(IBaseCrudRepository<CategoryEntity> inventoryRepository,
                                            ILogger<DeleteCategoryCommandHandler> logger)
        {
            _categoryRepository = inventoryRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _categoryRepository.GetEntityByIdAsync(request.Id);

            if (categoryToDelete == null)
            {
                _logger.LogError($"{request.Id} categoria no existe en el sistema");
                throw new NotFoundException(nameof(CategoryEntity), request.Id);
            }

            var categoryDeleted = await _categoryRepository.DeleteEntityByIdAsync(categoryToDelete);

            return categoryDeleted;
        }
    }
}
