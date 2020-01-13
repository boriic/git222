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
    public interface IVehicleModelService
    {
        Task AddVehicleModelAsync(VehicleModel vehicleModelEntity);
        Task <VehicleModel> GetVehicleModelAsync(int id);
        Task <IPagedList<VehicleModel>> GetVehicleModelsAsync(ISortParameters sort, IFilterParameters filter, IPageParameters pagep);
        Task UpdateVehicleModelAsync(VehicleModel updateVehicleModel);
        Task DeleteVehicleModelAsync(int id);
    }
}
