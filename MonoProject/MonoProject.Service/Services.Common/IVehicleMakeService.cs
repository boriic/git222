using MonoProject.Service.Models.Parameters_Models;
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
        void AddVehicleMake(VehicleMakeEntity vehicleMake);
        VehicleMakeEntity GetVehicleMake(int id);
        IPagedList<VehicleMakeEntity> GetVehicleMakes(SortParameters sort, FilterParameters filter, PageParameters pagep);
        void UpdateVehicleMake(VehicleMakeEntity UpdateVehicleMake);
        void DeleteVehicleMake(VehicleMakeEntity vehicleMakeDelete);
    }
}
