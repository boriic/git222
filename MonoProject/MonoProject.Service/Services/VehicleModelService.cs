using MonoProject.Service.Models.Parameters_Models;
using MonoProject.Service.Services.Common;
using PagedList;
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
        public async Task AddVehicleModel(VehicleModelEntity vehicleModel)
        {
            using (var ctx = new Context())
            {
                ctx.Entry(vehicleModel).State = EntityState.Added;
                await ctx.SaveChangesAsync();

            };
        }
        /// <summary>
        /// READING VEHICLE MODEL
        /// </summary>
        /// <param name="id"></param>
        public async Task <VehicleModelEntity> GetVehicleModel(int id)
        {
            using (var ctx = new Context())
            {
                var model = await ctx.VehicleModels.Where(x => x.Id == id).Include(m => m.VehicleMakeEntity).FirstOrDefaultAsync();
                return model;
            }
            
        }
        public async Task <IPagedList<VehicleModelEntity>> GetVehicleModels(SortParameters sort, FilterParameters filter, PageParameters pagep)
        {
            IQueryable<VehicleModelEntity> vehicleModels;
            using (var ctx = new Context())
            {
                
                if(!string.IsNullOrEmpty(filter.Search))
                {
                    vehicleModels =ctx.VehicleModels.Where(v => v.Name.ToUpper().StartsWith(filter.Search.ToUpper())).AsQueryable();
                }
                else
                {
                    vehicleModels = ctx.VehicleModels.AsQueryable();
                }
                if (filter.MakeId != null)
                {
                    vehicleModels =
                        vehicleModels.Where(v => v.VehicleMakeEntity.Id == filter.MakeId).AsQueryable();
                }
                //ORDER BY
                switch (sort.SortBy.ToUpper())
                {
                    case "NAME":
                        vehicleModels = vehicleModels.OrderBy(s => s.Name).AsQueryable();
                        break;
                    case "ID":
                        vehicleModels = vehicleModels.OrderBy(s => s.Id).AsQueryable();
                        break;
                    default:
                        vehicleModels = vehicleModels.OrderBy(s => s.Id).AsQueryable();
                        break;
                }
                //CHOOSING PAGE SIZE (HOW MUCH ELEMENTS TO SHOW ON PAGE)
                switch (pagep.PageSize)
                {
                    case 5:
                        pagep.PageSize = 5;
                        break;
                    case 10:
                        pagep.PageSize = 10;
                        break;
                    case 25:
                        pagep.PageSize = 25;
                        break;
                    case 50:
                        pagep.PageSize = 50;
                        break;
                }
                //ORDER BY DESCENDING
                if (sort.SortOrder?.ToUpper()=="DESC")
                {
                    vehicleModels = vehicleModels.OrderByDescending(s => s.Name).AsQueryable();
                    vehicleModels = vehicleModels.OrderByDescending(s => s.Id).AsQueryable();                  
                };
                return vehicleModels.ToPagedList(pagep.Page,pagep.PageSize);

            }
        }
        /// <summary>
        /// UPDATE VEHICLE MODEL
        /// </summary>
        /// <param name="updateVehicleModel"></param>
        public async Task UpdateVehicleModel(VehicleModelEntity updateVehicleModel)
        {
            using (var ctx = new Context())
            {
                if (updateVehicleModel != null)
                {
                    ctx.Entry(updateVehicleModel).State = EntityState.Modified;
                    await ctx.SaveChangesAsync();
                }

            }
        }
        /// <summary>
        /// REMOVE VEHICLE MODEL
        /// </summary>
        /// <param name="vehicleModelDelete"></param>
        public async Task DeleteVehicleModel(VehicleModelEntity vehicleModelDelete)
        {
            using (var ctx = new Context())
            {
                if (vehicleModelDelete != null)
                {
                    ctx.Entry(vehicleModelDelete).State = EntityState.Deleted;
                    await ctx.SaveChangesAsync();
                }

            }
        }
    }
}
