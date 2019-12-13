using MonoProject.Service.Models.Parameters_Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Service.Services.Common
{
    public interface IVehicleModelService
    {
        Task AddVehicleModel(VehicleModelEntity vehicleModel);
        Task <VehicleModelEntity> GetVehicleModel(int id);
        Task <IPagedList<VehicleModelEntity>> GetVehicleModels(SortParameters sort, FilterParameters filter, PageParameters pagep);
        Task UpdateVehicleModel(VehicleModelEntity updateVehicleModel);
        Task DeleteVehicleModel(VehicleModelEntity vehicleModelDelete);
    }
}
