using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList;
using System.Web.Mvc;
using MonoProject.DAL.Entities;
using MonoProject.DAL.Context;
using MonoProject.Repository.Common;
using MonoProject.Repository;
using MonoProject.Service.Common;
using MonoProject.Common.Parameters_Models;
using MonoProject.Model;
using MonoProject.Common.Interfaces;

namespace MonoProject.Service
{

    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IVehicleMakeRepository _repository;
        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            _repository = vehicleMakeRepository;
        }
        /// <summary>
        /// ADDING VEHICLE MAKE
        /// </summary>
        /// <param name="vehicleMake"></param>

        public async Task AddVehicleMakeAsync(VehicleMake vehicleMake)
        {
            await _repository.AddVehicleMakeAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(vehicleMake));
        }
        /// <summary>
        /// READING VEHICLE MAKE
        /// </summary>
        /// <param name="id"></param>
        public async Task<VehicleMake> GetVehicleMakeAsync(int id)
        {
            return AutoMapper.Mapper.Map<VehicleMake>(await _repository.GetVehicleMakeAsync(id));

        }

        public async Task<IPagedList<VehicleMake>> GetVehicleMakesAsync(ISortParameters sort, IFilterParameters filter, IPageParameters pagep)
        {
            var makeList = await _repository.GetVehicleMakesAsync(sort, filter, pagep);
            var makeVMList = AutoMapper.Mapper.Map<IEnumerable<VehicleMake>>(makeList);
            return new StaticPagedList<VehicleMake>(makeVMList, makeList.GetMetaData());
        }

        /// <summary>
        /// UPDATE VEHICLE MAKE
        /// </summary>
        /// <param name="UpdateVehicleMake"></param>

        public async Task UpdateVehicleMakeAsync(VehicleMake UpdateVehicleMake)
        {
            if (UpdateVehicleMake != null)
            {
                await _repository.UpdateVehicleMakeAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(UpdateVehicleMake));
            }
        }
        /// <summary>
        /// REMOVE VEHICLE MAKE
        /// </summary>

        public async Task DeleteVehicleMakeAsync(int id)
        {
            await _repository.DeleteVehicleMakeAsync(id);
        }
    }


}








