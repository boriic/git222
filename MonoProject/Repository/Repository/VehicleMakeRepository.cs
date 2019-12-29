using MonoProject.Common.Parameters_Models;
using MonoProject.DAL.Context;
using MonoProject.DAL.Entities;
using MonoProject.Repository.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        IQueryable<VehicleMakeEntity> vehicleMakes;

        private readonly Repository<VehicleMakeEntity> repository;

        public VehicleMakeRepository (Repository<VehicleMakeEntity> repository)
        {
            this.repository = repository;
        }
        /// <summary>
        /// ADD VEHICLE MAKE
        /// </summary>
        /// <param name="vehicleMakeEntity"></param>
        /// <returns></returns>
        public async Task AddVehicleMakeAsync(VehicleMakeEntity vehicleMakeEntity)
        {
            await repository.Insert(vehicleMakeEntity);
        }
        /// <summary>
        /// DELETE VEHICLE MAKE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteVehicleMakeAsync(int id)
        {
            VehicleMakeEntity vehicleMakeEntity = await repository.GetById(id);
            await repository.Delete(vehicleMakeEntity);
        }
        /// <summary>
        /// READ VEHICLE MAKE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<VehicleMakeEntity> GetVehicleMakeAsync(int id)
        {
            return await repository.GetById(id);
        }
        /// <summary>
        /// UPDATE VEHICLE MAKE
        /// </summary>
        /// <param name="UpdateVehicleMake"></param>
        /// <returns></returns>
        public async Task UpdateVehicleMakeAsync(VehicleMakeEntity UpdateVehicleMake)
        {
            await repository.Update(UpdateVehicleMake);
        }
        public async Task<IPagedList<VehicleMakeEntity>> GetVehicleMakesAsync(SortParameters sort, FilterParameters filter, PageParameters pagep)
        {
            
            //Search
            if (!string.IsNullOrEmpty(filter.Search))
            {
                vehicleMakes = repository.GetAll().Where(s => s.Name.ToUpper().StartsWith(filter.Search.ToUpper())).AsQueryable();
            }
            else
            {
                vehicleMakes = repository.GetAll().AsQueryable();
            }

            //OrderBy
            switch (sort.SortBy?.ToUpper())
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
            //ORDER BY DESCENDING
            if (sort.SortOrder?.ToUpper() == "DESC")
            {
                vehicleMakes = vehicleMakes.OrderByDescending(s => s.Name).AsQueryable();
                vehicleMakes = vehicleMakes.OrderByDescending(s => s.Id).AsQueryable();
            };
            return vehicleMakes.ToPagedList(pagep.Page, pagep.PageSize);
        }
    }
}
