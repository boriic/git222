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
        void AddVehicleModel(VehicleModelEntity vehicleModel);
        VehicleModelEntity GetVehicleModel(int id);
        IPagedList<VehicleModelEntity> GetVehicleModels(SortParameters sort, FilterParameters filter, PageParameters pagep);
        void UpdateVehicleModel(VehicleModelEntity updateVehicleModel);
        void DeleteVehicleModel(VehicleModelEntity vehicleModelDelete);
    }
}
