﻿using AutoMapper;
using BillWare.Application.Costumer.Command;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Shared;
using BillWare.Application.VehiculoEntrance.Entities;
using MediatR;

namespace BillWare.Application.Costumer.Handler
{
    public class UpdateVehicleEntranceCommandHandler : IRequestHandler<UpdateVehicleEntranceCommand, VehiculoEntranceVM>
    {
        private readonly IBaseCrudRepository<VehicleEntranceEntity> _costumerRepository;
        private readonly IMapper _mapper;

        public UpdateVehicleEntranceCommandHandler(IBaseCrudRepository<VehicleEntranceEntity> costumerRepository, IMapper mapper)
        {
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }

        public async Task<VehiculoEntranceVM> Handle(UpdateVehicleEntranceCommand request, CancellationToken cancellationToken)
        {
            var costumerToUpdate = _mapper.Map<VehicleEntranceEntity>(request.CostumerUpdate);

            var action = await _costumerRepository.Update(costumerToUpdate);

            var costumerMapped = _mapper.Map<VehiculoEntranceVM>(action);

            return costumerMapped;
        }
    }
}