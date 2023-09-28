using AutoMapper;
using BillWare.Application.Contracts;
using BillWare.Application.Features.Category.Entities;
using BillWare.Application.Features.Category.Models;
using BillWare.Application.Features.Category.Query;
using MediatR;

namespace BillWare.Application.Features.Category.Handler
{
    public class GetCategoriesPagedWithSearchQueryHandler : IRequestHandler<GetCategoriesPagedWithSearchQuery, PaginationResult<CategoryResponse>>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesPagedWithSearchQueryHandler(IBaseCrudRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<CategoryResponse>> Handle(GetCategoriesPagedWithSearchQuery request, CancellationToken cancellationToken)
        {
            var categoriesPaged = await _categoryRepository.GetEntitiesPagedWithSearch(request.Search, request.PageIndex, request.PageSize);

            var categoriesPagedMapped = _mapper.Map<PaginationResult<CategoryResponse>>(categoriesPaged);

            return categoriesPagedMapped;
        }
    }
}
