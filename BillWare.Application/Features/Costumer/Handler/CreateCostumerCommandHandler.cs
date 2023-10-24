using AutoMapper;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Features.Costumer.Command;
using BillWare.Application.Features.Costumer.Entities;
using BillWare.Application.Features.Costumer.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Costumer.Handler
{
    public class CreateCostumerCommandHandler : IRequestHandler<CreateCostumerCommand, CostumerResponse>
    {
        private readonly IBaseCrudRepository<CostumerEntity> _costumerRepository;
        private readonly ILogger<CreateCostumerCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateCostumerCommandHandler(IBaseCrudRepository<CostumerEntity> costumerRepository,
                                            ILogger<CreateCostumerCommandHandler> logger,
                                            IMapper mapper)
        {
            _logger = logger;
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }

        public async Task<CostumerResponse> Handle(CreateCostumerCommand request, CancellationToken cancellationToken)
        {
            var costumerToCreate = _mapper.Map<CostumerEntity>(request);

            var costumerRequest = await _costumerRepository.CreateEntityAsync(costumerToCreate);

            _logger.LogInformation($"Se ha creado la entidad Costumer con Id: {costumerRequest.Id}");

            var costumerResponse = _mapper.Map<CostumerResponse>(costumerRequest);

            return costumerResponse;
        }
    }
}
