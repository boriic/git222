﻿using MonoProject.Service.Models.Parameters_Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Service.Services.Common
{
    public interface IVehicleMakeService
    {
        Task AddVehicleMake(VehicleMakeEntity vehicleMake);
        Task <VehicleMakeEntity> GetVehicleMake(int id);
        Task <IPagedList<VehicleMakeEntity>> GetVehicleMakes(SortParameters sort, FilterParameters filter, PageParameters pagep);
        Task UpdateVehicleMake(VehicleMakeEntity UpdateVehicleMake);
        Task DeleteVehicleMake(VehicleMakeEntity vehicleMakeDelete);
    }
}
