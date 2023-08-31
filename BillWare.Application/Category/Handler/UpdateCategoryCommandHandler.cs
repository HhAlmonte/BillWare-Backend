using AutoMapper;
using BillWare.Application.Category.Command;
using BillWare.Application.Category.Entities;
using BillWare.Application.Category.Models;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Category.Handler
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponse>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IBaseCrudRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = _mapper.Map<CategoryEntity>(request.Request);

            var updatedCategory = await _categoryRepository.UpdateEntityAsync(categoryToUpdate);

            var categoryResponse = _mapper.Map<CategoryResponse>(updatedCategory);

            return categoryResponse;
        }
    }
}
