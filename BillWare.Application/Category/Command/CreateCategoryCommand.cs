using BillWare.Application.Category.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillWare.Application.Category.Command
{
    public class CreateCategoryCommand : IRequest<CategoryVM>
    {
        public CategoryCommandModel Category { get; set; }

        public CreateCategoryCommand(CategoryCommandModel category)
        {
            Category = category;
        }
    }
}
