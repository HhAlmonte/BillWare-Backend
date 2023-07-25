using BillWare.Application.Category.Command;
using BillWare.Application.Category.Entities;
using BillWare.Application.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillWare.Application.Category.Handler
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IBaseCrudRepository<CategoryEntity> _categoryRepository;
        
        public DeleteCategoryCommandHandler(IBaseCrudRepository<CategoryEntity> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.Delete(request.Id);
        }
    }
}
