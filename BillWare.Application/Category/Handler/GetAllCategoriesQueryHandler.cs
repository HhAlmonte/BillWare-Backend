using AutoMapper;
using BillWare.Application.Category.Entities;
using BillWare.Application.Category.Models;
using BillWare.Application.Category.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Category.Handler
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoryQuery, PaginationResult<CategoryVM>>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IBaseCrudRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<CategoryVM>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.Get(request.Page, request.PageSize);

            var categoriesVM = _mapper.Map<PaginationResult<CategoryVM>>(categories);

            return categoriesVM;
        }
    }
}
