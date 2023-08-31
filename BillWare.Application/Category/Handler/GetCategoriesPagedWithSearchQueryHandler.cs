﻿using AutoMapper;
using BillWare.Application.Category.Entities;
using BillWare.Application.Category.Models;
using BillWare.Application.Category.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.Category.Handler
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
            var categories = await _categoryRepository.GetEntitiesPagedWithSearch(request.Search, request.PageIndex, request.PageSize);

            var categoriesResponse = _mapper.Map<PaginationResult<CategoryResponse>>(categories);

            return categoriesResponse;
        }
    }
}