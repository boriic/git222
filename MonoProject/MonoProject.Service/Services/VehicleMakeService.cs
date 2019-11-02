using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList;
using System.Web.Mvc;

namespace MonoProject.Service
{

    public class VehicleMakeService
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

        public List<VehicleMakeEntity> GetVehicleMakes(string search, string sortOrder)
        {
            List<VehicleMakeEntity> vehicleMakes;
            using (var ctx = new Context())
            {
                if(!string.IsNullOrEmpty(search))
                {
                    vehicleMakes = ctx.VehicleMakes.Where(s => s.Name.ToUpper().StartsWith(search.ToUpper())).ToList();
                }
                else
                {
                    vehicleMakes = ctx.VehicleMakes.ToList();
                }
                switch (sortOrder.ToUpper())
                {                 
                    case "Z-A":
                        vehicleMakes = vehicleMakes.OrderByDescending(s => s.Name).ToList();
                        break;
                    case "NEWEST":
                        vehicleMakes = vehicleMakes.OrderByDescending(s => s.Id).ToList();
                        break;
                    case "OLDEST":
                        vehicleMakes = vehicleMakes.OrderBy(s => s.Id).ToList();
                        break;
                    case "A-Z":
                        vehicleMakes = vehicleMakes.OrderBy(s => s.Name).ToList();
                        break;
                    default:
                        break;
                }
                return vehicleMakes;
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








