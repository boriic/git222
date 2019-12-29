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

namespace MonoProject.Service
{

    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IVehicleMakeRepository _vehicleMakeRepository;
        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
        }
        /// <summary>
        /// ADDING VEHICLE MAKE
        /// </summary>
        /// <param name="vehicleMake"></param>

        public async Task AddVehicleMakeAsync(VehicleMake vehicleMake)
        {
            await _vehicleMakeRepository.AddVehicleMakeAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(vehicleMake));
        }
        /// <summary>
        /// READING VEHICLE MAKE
        /// </summary>
        /// <param name="id"></param>
        public async Task<VehicleMake> GetVehicleMakeAsync(int id)
        {
            return AutoMapper.Mapper.Map<VehicleMake>(await _vehicleMakeRepository.GetVehicleMakeAsync(id));

        }

        public async Task<IPagedList<VehicleMake>> GetVehicleMakesAsync(SortParameters sort, FilterParameters filter, PageParameters pagep)
        {
            var makeList = await _vehicleMakeRepository.GetVehicleMakesAsync(sort, filter, pagep);
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
                await _vehicleMakeRepository.UpdateVehicleMakeAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(UpdateVehicleMake));
            }
        }
        /// <summary>
        /// REMOVE VEHICLE MAKE
        /// </summary>

        public async Task DeleteVehicleMakeAsync(int id)
        {
            await _vehicleMakeRepository.DeleteVehicleMakeAsync(id);
        }
    }


}








