using AutoMapper;
using BillWare.Application.Category.Command;
using BillWare.Application.Category.Entities;
using BillWare.Application.Category.Models;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Category.Handler
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryVM>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IBaseCrudRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryVM> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = _mapper.Map<CategoryEntity>(request.Category);

            var action = await _categoryRepository.Update(request.Id, categoryToUpdate);

            return _mapper.Map<CategoryVM>(action);
        }
    }
}
