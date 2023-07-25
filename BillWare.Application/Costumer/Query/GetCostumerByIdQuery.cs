using BillWare.Application.Costumer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillWare.Application.Costumer.Query
{
    public class GetCostumerByIdQuery : IRequest<CostumerVM>
    {
        public int Id { get; set; }

        public GetCostumerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
