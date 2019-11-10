using MonoProject.Service.Models.Parameters_Models;
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
        List<VehicleMakeEntity> GetVehicleMakes(SortParameters sort, FilterParameters filter);
        void UpdateVehicleMake(VehicleMakeEntity UpdateVehicleMake);
        void DeleteVehicleMake(VehicleMakeEntity vehicleMakeDelete);
    }
}
