using AutoMapper;
using BillWare.Application.Contracts;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Costumer.Entities;
using BillWare.Application.Features.Costumer.Models;
using BillWare.Application.Features.Costumer.Query;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Costumer.Handler
{
    public class GetCostumerByIdQueryHandler : IRequestHandler<GetCostumerByIdQuery, CostumerResponse>
    {
        private readonly IBaseCrudRepository<CostumerEntity> _costumerRepository;
        private readonly ILogger<GetCostumerByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetCostumerByIdQueryHandler(IBaseCrudRepository<CostumerEntity> costumerRepository,
                                           ILogger<GetCostumerByIdQueryHandler> logger,
                                           IMapper mapper)
        {
            _logger = logger;
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }

        public async Task<CostumerResponse> Handle(GetCostumerByIdQuery request, CancellationToken cancellationToken)
        {
            var costumer = await _costumerRepository.GetEntityByIdAsync(request.Id);

            if (costumer == null)
            {
                _logger.LogError($"No se ha encontrado la entidad Costumer con Id: {request.Id}");
                throw new NotFoundException(nameof(CostumerEntity), request.Id);
            }

            return _mapper.Map<CostumerResponse>(costumer);
        }
    }
}
