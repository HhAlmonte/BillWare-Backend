using BillWare.Application.Category.Command;
using BillWare.Application.Category.Entities;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Category.Handler
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;

        public DeleteCategoryCommandHandler(IBaseCrudRepository<CategoryEntity> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _categoryRepository.Delete(request.Id);
            }
            catch (CrudOperationException)
            {
                throw new CrudOperationException("Error eliminando la entidad Categoria. Hablar con el administrador del sistema.");
            }
        }
    }
}
