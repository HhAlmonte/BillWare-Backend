using BillWare.Application.Category.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillWare.Application.Category.Command
{
    public class UpdateCategoryCommand : IRequest<CategoryVM>
    {
        public int Id { get; set; }
        public CategoryCommandModel Category { get; set; }

        public UpdateCategoryCommand(int id, CategoryCommandModel category)
        {
            Id = id;
            Category = category;
        }
    }
}
