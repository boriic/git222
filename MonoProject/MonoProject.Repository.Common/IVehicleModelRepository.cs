using MonoProject.Common.Interfaces;
using MonoProject.Common.Parameters_Models;
using MonoProject.DAL.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IVehicleModelRepository
    {
        Task AddVehicleModelAsync(VehicleModelEntity vehicleModel);
        Task<VehicleModelEntity> GetVehicleModelAsync(int id);
        Task<IPagedList<VehicleModelEntity>> GetVehicleModelsAsync(ISortParameters sort, IFilterParameters filter, IPageParameters pagep);
        Task UpdateVehicleModelAsync(VehicleModelEntity updateVehicleModel);
        Task DeleteVehicleModelAsync(int id);
    }
}
