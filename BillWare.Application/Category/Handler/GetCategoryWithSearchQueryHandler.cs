using AutoMapper;
using BillWare.Application.Category.Entities;
using BillWare.Application.Category.Models;
using BillWare.Application.Category.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Category.Handler
{
    public class GetCategoryWithSearchQueryHandler : IRequestHandler<GetCategoryWithSearchQuery, PaginationResult<CategoryVM>>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryWithSearchQueryHandler(IBaseCrudRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<CategoryVM>> Handle(GetCategoryWithSearchQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetWithSearch(request.Search, request.PageIndex, request.PageSize);

            return _mapper.Map<PaginationResult<CategoryVM>>(category);
        }
    }
}
