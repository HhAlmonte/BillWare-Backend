﻿using BillWare.Application.Shared.Models;
using BillWare.Application.VehiculoEntrance.Models;

namespace BillWare.Application.Costumer.Models
{
    public class VehiculoEntranceVM : BaseViewModel
    {
        public CostumerModel Costumer { get; set; }
        public List<VehicleModel> Vehicles { get; set; }
    }
}