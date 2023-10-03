using AutoMapper;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Category.Command;
using BillWare.Application.Features.Category.Entities;
using BillWare.Application.Features.Category.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Category.Handler
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponse>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IBaseCrudRepository<CategoryEntity> categoryRepository,
                                            ILogger<UpdateCategoryCommandHandler> logger,
                                            IMapper mapper)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = _mapper.Map<CategoryEntity>(request);

            var categoryFromDb = await _categoryRepository.GetEntityByIdAsync(categoryToUpdate.Id);

            if (categoryFromDb == null)
            {
                _logger.LogError($"La entidad Categoria con Id: {categoryToUpdate.Id} no existe en la base de datos");
                throw new NotFoundException(nameof(CategoryEntity), categoryToUpdate.Id);
            }

            var categoryUpdated = await _categoryRepository.UpdateEntityAsync(categoryToUpdate);

            _logger.LogInformation($"Se ha actualizado la entidad Categoria con Id: {categoryUpdated.Id}");

            var categoryResponse = _mapper.Map<CategoryResponse>(categoryUpdated);

            return categoryResponse;
        }
    }
}
