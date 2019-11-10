using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Service.Services.Common
{
    public interface IVehicleMakeService
    {
        void AddVehicleMake(VehicleMakeEntity vehicleMake);
        VehicleMakeEntity GetVehicleMake(int id);
        List<VehicleMakeEntity> GetVehicleMakes(string search, string sortOrder);
        void UpdateVehicleMake(VehicleMakeEntity UpdateVehicleMake);
        void DeleteVehicleMake(VehicleMakeEntity vehicleMakeDelete);
    }
}
