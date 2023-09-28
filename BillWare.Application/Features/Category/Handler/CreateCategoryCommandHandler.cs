using AutoMapper;
using BillWare.Application.Contracts;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Category.Command;
using BillWare.Application.Features.Category.Entities;
using BillWare.Application.Features.Category.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Category.Handler
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponse>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;
        private readonly ILogger<CreateCategoryCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IBaseCrudRepository<CategoryEntity> categoryRepository,
                                            ILogger<CreateCategoryCommandHandler> logger,   
                                            IMapper mapper)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToCreate = _mapper.Map<CategoryEntity>(request);

            var categoryCreated = await _categoryRepository.CreateEntityAsync(categoryToCreate);

            _logger.LogInformation($"Se ha creado la entidad Categoria con Id: {categoryCreated.Id}");

            var categoryCreatedMapped = _mapper.Map<CategoryResponse>(categoryCreated);

            return categoryCreatedMapped;
        }
    }
}
