using AutoMapper;
using BillWare.Application.Category.Command;
using BillWare.Application.Category.Entities;
using BillWare.Application.Category.Models;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Category.Handler
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryVM>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryReposity;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IBaseCrudRepository<CategoryEntity> categoryReposity, IMapper mapper)
        {
            _categoryReposity = categoryReposity;
            _mapper = mapper;
        }

        public async Task<CategoryVM> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoryToCreate = _mapper.Map<CategoryEntity>(request.Category);

                var action = await _categoryReposity.Create(categoryToCreate);

                var categoryVM = _mapper.Map<CategoryVM>(action);

                return categoryVM;
            }
            catch (CrudOperationException)
            {
                throw new CrudOperationException("Error creando la entidad Categoria. Hablar con el administrador del sistema.");
            }
        }
    }
}
