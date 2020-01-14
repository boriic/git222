using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MonoProject.Service.Common;
using MonoProject.Common.Parameters_Models;
using MonoProject.Repository.Common;
using MonoProject.Model;
using MonoProject.Common.Interfaces;
using MonoProject.DAL.Entities;

namespace MonoProject.Service
{
   public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository _repository;
        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            _repository = vehicleModelRepository;
        }
        /// <summary>
        /// ADDING VEHICLE MODEL
        /// </summary>
        /// <param name="vehicleModel"></param>
        public async Task AddVehicleModelAsync(VehicleModel vehicleModel)
        {
            await _repository.AddVehicleModelAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(vehicleModel));
        }
        /// <summary>
        /// READING VEHICLE MODEL
        /// </summary>
        /// <param name="id"></param>
        public async Task <VehicleModel> GetVehicleModelAsync(int id)
        {
            return AutoMapper.Mapper.Map<VehicleModel>(await _repository.GetVehicleModelAsync(id));
        }
        public async Task <IPagedList<VehicleModel>> GetVehicleModelsAsync(ISortParameters sort, IFilterParameters filter, IPageParameters pagep)
        {
            var modelList = await _repository.GetVehicleModelsAsync(sort, filter, pagep);
            var makeVMList = AutoMapper.Mapper.Map<IEnumerable<VehicleModel>>(modelList);
            return new StaticPagedList<VehicleModel>(makeVMList, modelList.GetMetaData());
        }
        /// <summary>
        /// UPDATE VEHICLE MODEL
        /// </summary>
        /// <param name="updateVehicleModel"></param>
        public async Task UpdateVehicleModelAsync(VehicleModel updateVehicleModel)
        {
                if (updateVehicleModel != null)
                {
                    await _repository.UpdateVehicleModelAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(updateVehicleModel));
                }
        }
        /// <summary>
        /// REMOVE VEHICLE MODEL
        /// </summary>
        /// <param name="vehicleModelDelete"></param>
        public async Task DeleteVehicleModelAsync(int id)
        {
            await _repository.DeleteVehicleModelAsync(id);
        }
    }
}
