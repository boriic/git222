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
    public interface IVehicleMakeRepository 
    {
        Task AddVehicleMakeAsync(VehicleMakeEntity vehicleMake);
        Task<VehicleMakeEntity> GetVehicleMakeAsync(int id);
        Task<IPagedList<VehicleMakeEntity>> GetVehicleMakesAsync(ISortParameters sort, IFilterParameters filter, IPageParameters pagep);
        Task UpdateVehicleMakeAsync(VehicleMakeEntity updateVehicleMake);
        Task DeleteVehicleMakeAsync(int id);
    }
}
