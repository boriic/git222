using MonoProject.Service.Models.Parameters_Models;
using MonoProject.Service.Services.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MonoProject.Service
{
   public class VehicleModelService : IVehicleModelService
    {
        /// <summary>
        /// ADDING VEHICLE MODEL
        /// </summary>
        /// <param name="vehicleModel"></param>
        public void AddVehicleModel(VehicleModelEntity vehicleModel)
        {
            using (var ctx = new Context())
            {
                ctx.Entry(vehicleModel).State = EntityState.Added;
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
        public List<VehicleModelEntity> GetVehicleModels(SortParameters sort, FilterParameters filter)
        {
            IQueryable<VehicleModelEntity> vehicleModels;
            using (var ctx = new Context())
            {
                if(!string.IsNullOrEmpty(filter.Search))
                {
                    return ctx.VehicleModels.Where(v => v.Name.ToUpper().StartsWith(filter.Search.ToUpper())).ToList();
                }
                else
                {
                    vehicleModels = ctx.VehicleModels.AsQueryable();
                }

                //ORDER BY
                switch (sort.SortBy.ToUpper())
                {
                    case "NAME":
                        vehicleModels = vehicleModels.OrderBy(s => s.Name).AsQueryable();
                        break;
                    case "ID":
                        vehicleModels = vehicleModels.OrderByDescending(s => s.Id).AsQueryable();
                        break;
                    default:
                        break;
                }

                //OrderDirection
                switch (sort.SortOrder.ToUpper())
                {
                    case "ASC":
                        vehicleModels = vehicleModels.OrderBy(s => s.Name).AsQueryable();
                        break;
                    case "DESC":
                        vehicleModels = vehicleModels.OrderByDescending(s => s.Name).AsQueryable();
                        break;
                    default:
                        break;
                }
                return vehicleModels.ToList();
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
                ctx.Entry(updateVehicleModel).State = EntityState.Modified;
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
                ctx.Entry(vehicleModelDelete).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }
    }
}
