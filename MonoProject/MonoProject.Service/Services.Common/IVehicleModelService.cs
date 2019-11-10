using MonoProject.Service.Models.Parameters_Models;
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
        List<VehicleModelEntity> GetVehicleModels(SortParameters sort, FilterParameters filter);
        void UpdateVehicleModel(VehicleModelEntity updateVehicleModel);
        void DeleteVehicleModel(VehicleModelEntity vehicleModelDelete);
    }
}
