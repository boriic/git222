using MonoProject.Common.Interfaces;
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
    public class VehicleModelRepository : IVehicleModelRepository
    {
        IQueryable<VehicleModelEntity> vehicleModels;
        private readonly IRepository<VehicleModelEntity> repository;
        public VehicleModelRepository(IRepository<VehicleModelEntity> repository)
        {
            this.repository = repository;
        }
        /// <summary>
        /// ADD VEHICLE MODEL
        /// </summary>
        /// <param name="vehicleModelEntity"></param>
        /// <returns></returns>
        public async Task AddVehicleModelAsync(VehicleModelEntity vehicleModelEntity)
        {
            await repository.Insert(vehicleModelEntity);
        }
        /// <summary>
        /// DELETE VEHICLE MODEL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteVehicleModelAsync(int id)
        {
            VehicleModelEntity vehicleModelEntity = await repository.GetById(id);
            await repository.Delete(vehicleModelEntity);
        }
        /// <summary>
        /// READING VEHICLE MODEL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<VehicleModelEntity> GetVehicleModelAsync(int id)
        {
            return await repository.GetById(id);
        }
        public async Task UpdateVehicleModelAsync(VehicleModelEntity updateVehicleModel)
        {
            await repository.Update(updateVehicleModel);
        }
        public async Task<IPagedList<VehicleModelEntity>> GetVehicleModelsAsync(ISortParameters sort, IFilterParameters filter, IPageParameters pagep)
        {
            if (!string.IsNullOrEmpty(filter.Search))
            {
               vehicleModels = repository.GetAll().Where(v => v.Name.ToUpper().StartsWith(filter.Search.ToUpper())).AsQueryable();
            }
            else
            {
               vehicleModels = repository.GetAll().AsQueryable();
            }
            if (filter.MakeId != null)
            {
                vehicleModels =
                    vehicleModels.Where(v => v.VehicleMakeEntity.Id == filter.MakeId).AsQueryable();
            }
            //ORDER BY
            switch (sort.SortBy?.ToUpper())
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
            //ORDER BY DESCENDING
            if (sort.SortOrder?.ToUpper() == "DESC")
            {
                vehicleModels = vehicleModels.OrderByDescending(s => s.Name).AsQueryable();
                vehicleModels = vehicleModels.OrderByDescending(s => s.Id).AsQueryable();
            };
            return vehicleModels.ToPagedList(pagep.Page, pagep.PageSize);
        }
    }
}
