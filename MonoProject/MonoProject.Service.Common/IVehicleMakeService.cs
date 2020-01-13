using MonoProject.Common.Interfaces;
using MonoProject.Common.Parameters_Models;
using MonoProject.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Service.Common
{
    public interface IVehicleMakeService
    {
        Task AddVehicleMakeAsync(VehicleMake vehicleMakeEntity);
        Task <VehicleMake> GetVehicleMakeAsync(int id);
        Task <IPagedList<VehicleMake>> GetVehicleMakesAsync(ISortParameters sort, IFilterParameters filter, IPageParameters pagep);
        Task UpdateVehicleMakeAsync(VehicleMake UpdateVehicleMake);
        Task DeleteVehicleMakeAsync(int id);
    }
}
