using AutoMapper;
using Mono.Project.WebAPI.Models;
using MonoProject.Common.Parameters_Models;
using MonoProject.Model;
using MonoProject.Service.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Mono.Project.WebAPI.Controllers
{
    [RoutePrefix("vehiclemake")]
    public class VehicleMakeController : ApiController
    {
        private readonly IVehicleMakeService _vehicleMakeService;
        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }
        // GET: api/getvehiclemakes
        [Route("api/getvehiclemakes")]
        public async Task<IHttpActionResult> GetVehicleMakesAsync(string search, int? page = 1, int pageSize = 5, string sortOrder = "", string sortBy = "")
        {
            var filter = new FilterParameters
            {
                Search = search
            };
            var sort = new SortParameters
            {
                SortBy = sortBy,
                SortOrder = sortOrder
            };
            var pagep = new PageParameters
            {
                Page = (int)page,
                PageSize = pageSize
            };
            var vmlist = await _vehicleMakeService.GetVehicleMakesAsync(sort, filter, pagep);
            var makeVMList = AutoMapper.Mapper.Map<IEnumerable<VehicleMakeVM>>(vmlist);
            return Ok(new { 
            data = makeVMList,paggingInfo = vmlist.GetMetaData()});
        }
        // GET: api/getvehiclemake
        [Route("api/getvehiclemake")]
        [HttpGet]
        [ResponseType(typeof(VehicleMakeVM))]
        public async Task<IHttpActionResult> GetVehicleMakeAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehicleMake = await _vehicleMakeService.GetVehicleMakeAsync((int)id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(vehicleMake);
        }

        // PUT: api/updatevehiclemake
        [Route("api/updatevehiclemake")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> UpdateVehicleMakeAsync(int id, VehicleMakeVM vehicleMake)
        {
            if (ModelState.IsValid)
            {
                await _vehicleMakeService.UpdateVehicleMakeAsync(Mapper.Map<VehicleMake>(vehicleMake));
            }
            if (id != vehicleMake.Id)
            {
                return BadRequest();
            }

            if (vehicleMake == null)
            {
                return NotFound();
            }
            return Ok(vehicleMake);
        }
        // POST: api/createvehiclemake
        [Route("api/createvehiclemake")]
        [HttpPost]
        [ResponseType(typeof(VehicleMakeVM))]
        public async Task<IHttpActionResult> CreateVehicleMakeAsync(VehicleMakeVM vehicleMake)
        {
            if (ModelState.IsValid)
            {
                await _vehicleMakeService.AddVehicleMakeAsync(Mapper.Map<VehicleMake>(vehicleMake));
                return CreatedAtRoute("DefaultApi", new { id = vehicleMake.Id }, vehicleMake);
            }
            return Ok(vehicleMake);
        }
        // DELETE: api/deletevehiclemake
        [Route("api/deletevehiclemake")]
        [HttpDelete]
        [ResponseType(typeof(VehicleMakeVM))]
        public async Task<IHttpActionResult> DeleteVehicleMakeAsync(int id)
        {
            VehicleMakeVM vehicleMake = Mapper.Map<VehicleMakeVM>(await _vehicleMakeService.GetVehicleMakeAsync((int)id));
            if (vehicleMake == null)
            {
                return NotFound();
            }
            await _vehicleMakeService.DeleteVehicleMakeAsync((int)id);
            return Ok(vehicleMake);
        }
    }
}
