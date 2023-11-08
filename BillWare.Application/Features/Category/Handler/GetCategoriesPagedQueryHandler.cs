using AutoMapper;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Features.Category.Entities;
using BillWare.Application.Features.Category.Models;
using BillWare.Application.Features.Category.Query;
using MediatR;

namespace BillWare.Application.Features.Category.Handler
{
    public class GetCategoriesPagedQueryHandler : IRequestHandler<GetCategoriesPagedQuery, PaginationResult<CategoryResponse>>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesPagedQueryHandler(IBaseCrudRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<PaginationResult<CategoryResponse>> Handle(GetCategoriesPagedQuery request, CancellationToken cancellationToken)
        {
            var categoriesPaged = await _categoryRepository.GetEntitiesPaged(request.PageIndex, request.PageSize);

            var categoriesPagedMapped = _mapper.Map<PaginationResult<CategoryResponse>>(categoriesPaged);

            return categoriesPagedMapped;
        }
    }
}
