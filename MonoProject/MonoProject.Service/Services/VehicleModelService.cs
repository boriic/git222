using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Service
{
   public class VehicleModelService
    {
        /// <summary>
        /// ADDING VEHICLE MODEL
        /// </summary>
        /// <param name="vehicleModel"></param>
        public void AddVehicleModel(VehicleModelEntity vehicleModel)
        {
            using (var ctx = new Context())
            {
                ctx.VehicleModels.Add(vehicleModel);
                ctx.SaveChanges();

            };
        }
        /// <summary>
        /// READING VEHICLE MODEL
        /// </summary>
        /// <param name="id"></param>
        public VehicleModelEntity GetVehicleModel(int id)
        {
            using (var ctx = new Context())
            {
                return ctx.VehicleModels.Where(x => x.Id == id).FirstOrDefault();
            }
            
        }
        public List<VehicleModelEntity> GetVehicleModels(string search, string sortOrder)
        {
            List<VehicleModelEntity> vehicleModels;
            using (var ctx = new Context())
            {
                if(!string.IsNullOrEmpty(search))
                {
                    return ctx.VehicleModels.Where(v => v.Name.ToUpper().StartsWith(search.ToUpper())).ToList();
                }
                else
                {
                    vehicleModels = ctx.VehicleModels.ToList();
                }
                switch (sortOrder.ToUpper())
                {
                    case "Z-A":
                        vehicleModels = vehicleModels.OrderByDescending(s => s.Name).ToList();
                        break;
                    case "A-Z":
                        vehicleModels = vehicleModels.OrderBy(s => s.Name).ToList();
                        break;
                    case "NEWEST":
                        vehicleModels = vehicleModels.OrderByDescending(s => s.Id).ToList();
                        break;
                    case "OLDEST":
                        vehicleModels = vehicleModels.OrderBy(s => s.Id).ToList();
                        break;
                }
                return vehicleModels;
            }
        }
        /// <summary>
        /// UPDATE VEHICLE MODEL
        /// </summary>
        /// <param name="updateVehicleModel"></param>
        public void UpdateVehicleModel(VehicleModelEntity updateVehicleModel)
        {
            using (var ctx = new Context())
            {
                var existingVehicleModel = ctx.VehicleModels.Where(x => x.Id == updateVehicleModel.Id).FirstOrDefault();
                existingVehicleModel = updateVehicleModel;
                ctx.SaveChanges();
            }
        }
        /// <summary>
        /// REMOVE VEHICLE MODEL
        /// </summary>
        /// <param name="vehicleModelDelete"></param>
        public void DeleteVehicleModel(VehicleModelEntity vehicleModelDelete)
        {
            using (var ctx = new Context())
            {
                ctx.VehicleModels.Remove(vehicleModelDelete);
                ctx.SaveChanges();
            }
        }
    }
}
