using AutoMapper;
using BillWare.Application.Category.Entities;
using BillWare.Application.Category.Models;
using BillWare.Application.Category.Query;
using BillWare.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillWare.Application.Category.Handler
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryVM>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IBaseCrudRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryVM> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.Id);

            return _mapper.Map<CategoryVM>(category);
        }
    }
}
