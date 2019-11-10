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

        public void AddVehicleMake(VehicleMakeEntity vehicleMake)
        {
            using (var ctx = new Context())
            {
                ctx.VehicleMakes.Add(vehicleMake);
                ctx.SaveChanges();

            };
        }
        /// <summary>
        /// READING VEHICLE MAKE
        /// </summary>
        /// <param name="id"></param>
        public VehicleMakeEntity GetVehicleMake(int id)
        {
            using (var ctx = new Context())
            {
               return ctx.VehicleMakes.Where(x => x.Id == id).FirstOrDefault();   
            }
        }

        public List<VehicleMakeEntity> GetVehicleMakes(SortParameters sort, FilterParameters filter)
        {
            IQueryable<VehicleMakeEntity> vehicleMakes;
            using (var ctx = new Context())
            {
                //Search
                if(!string.IsNullOrEmpty(filter.Search))
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
                    case "Name":
                        vehicleMakes = vehicleMakes.OrderBy(s => s.Name).AsQueryable();
                        break;
                    case "Id":
                        vehicleMakes = vehicleMakes.OrderBy(s => s.Id).AsQueryable();
                        break;
                    default:
                        break;
                }

                //OrderDirection
                if(sort.SortOrder.ToUpper() == "DESC")
                {
                    vehicleMakes = vehicleMakes.Reverse();
                }

                return vehicleMakes.ToList();
            }
           
        }

        /// <summary>
        /// UPDATE VEHICLE MAKE
        /// </summary>
        /// <param name="UpdateVehicleMake"></param>

        public void UpdateVehicleMake(VehicleMakeEntity UpdateVehicleMake)
        {
            using (var ctx = new Context())
            {
                ctx.Entry(UpdateVehicleMake).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
        /// <summary>
        /// REMOVE VEHICLE MAKE
        /// </summary>
        
        public void DeleteVehicleMake(VehicleMakeEntity vehicleMakeDelete)
        {
            using (var ctx = new Context())
            {
                ctx.Entry(vehicleMakeDelete).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }
    }


}








