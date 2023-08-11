using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Query
{
    public class GetCostumerByIdQuery : IRequest<CostumerModel>
    {
        public int Id { get; set; }

        public GetCostumerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
