using AutoMapper;
using BillWare.Application.Category.Command;
using BillWare.Application.Category.Entities;
using BillWare.Application.Category.Models;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Inventory.Handler
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponse>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IBaseCrudRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoryToCreate = _mapper.Map<CategoryEntity>(request.Request);

                var createdInventory = await _categoryRepository.CreateEntityAsync(categoryToCreate);

                var categoryResponse = _mapper.Map<CategoryResponse>(createdInventory);

                return categoryResponse;
            }
            catch (CrudOperationException)
            {
                throw new CrudOperationException("Error creando la entidad Categoria. Hablar con el administrador del sistema.");
            }
        }
    }
}
