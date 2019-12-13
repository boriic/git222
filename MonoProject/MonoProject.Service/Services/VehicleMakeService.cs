using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList;
using System.Web.Mvc;
using MonoProject.Service.Services.Common;
using MonoProject.Service.Models.Parameters_Models;

namespace MonoProject.Service
{

    public class VehicleMakeService : IVehicleMakeService
    {
        /// <summary>
        /// ADDING VEHICLE MAKE
        /// </summary>
        /// <param name="vehicleMake"></param>

        public async Task AddVehicleMake(VehicleMakeEntity vehicleMake)
        {
            using (var ctx = new Context())
            {
                ctx.Entry(vehicleMake).State = EntityState.Added;
                await ctx.SaveChangesAsync();
            };
        }
        /// <summary>
        /// READING VEHICLE MAKE
        /// </summary>
        /// <param name="id"></param>
        public async Task <VehicleMakeEntity> GetVehicleMake(int id)
        {
            using (var ctx = new Context())
            {
                return await ctx.VehicleMakes.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
        }

        public async Task <IPagedList<VehicleMakeEntity>> GetVehicleMakes(SortParameters sort, FilterParameters filter, PageParameters pagep)
        {
            IQueryable<VehicleMakeEntity> vehicleMakes;
            using (var ctx = new Context())
            {
                //Search
                if (!string.IsNullOrEmpty(filter.Search))
                {
                    vehicleMakes = ctx.VehicleMakes.Where(s => s.Name.ToUpper().StartsWith(filter.Search.ToUpper())).AsQueryable();
                }
                else
                {
                    vehicleMakes = ctx.VehicleMakes.AsQueryable();
                }

                //OrderBy
                switch (sort.SortBy.ToUpper())
                {
                    case "NAME":
                        vehicleMakes = vehicleMakes.OrderBy(s => s.Name).AsQueryable();
                        break;
                    case "ID":
                        vehicleMakes = vehicleMakes.OrderBy(s => s.Id).AsQueryable();
                        break;
                    default:
                        vehicleMakes = vehicleMakes.OrderBy(s => s.Id).AsQueryable();
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
                if (sort.SortOrder?.ToUpper() == "DESC")
                {
                    vehicleMakes = vehicleMakes.OrderByDescending(s => s.Name).AsQueryable();
                    vehicleMakes = vehicleMakes.OrderByDescending(s => s.Id).AsQueryable();
                };
                return vehicleMakes.ToPagedList(pagep.Page, pagep.PageSize);
            }
        }

        /// <summary>
        /// UPDATE VEHICLE MAKE
        /// </summary>
        /// <param name="UpdateVehicleMake"></param>

        public async Task UpdateVehicleMake(VehicleMakeEntity UpdateVehicleMake)
        {
            using (var ctx = new Context())
            {
                if (UpdateVehicleMake != null)
                {
                    ctx.Entry(UpdateVehicleMake).State = EntityState.Modified;
                    await ctx.SaveChangesAsync();
                }

            }
        }
        /// <summary>
        /// REMOVE VEHICLE MAKE
        /// </summary>

        public async Task DeleteVehicleMake(VehicleMakeEntity vehicleMakeDelete)
        {
            using (var ctx = new Context())
            {
                if (vehicleMakeDelete != null)
                {
                    ctx.Entry(vehicleMakeDelete).State = EntityState.Deleted;
                    await ctx.SaveChangesAsync();
                }
            }
        }
    }


}








