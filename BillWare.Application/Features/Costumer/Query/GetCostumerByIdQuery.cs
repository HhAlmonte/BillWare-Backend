using BillWare.Application.Features.Costumer.Models;
using MediatR;

namespace BillWare.Application.Features.Costumer.Query
{
    public class GetCostumerByIdQuery : IRequest<CostumerResponse>
    {
        public int Id { get; set; }

        public GetCostumerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
