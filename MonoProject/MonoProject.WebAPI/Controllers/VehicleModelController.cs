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
    [RoutePrefix("VehicleModel")]
    public class VehicleModelController : ApiController
    {
        private readonly IVehicleModelService _vehicleModelService;
        public VehicleModelController(IVehicleModelService vehicleModelService)
        {
            _vehicleModelService = vehicleModelService;
        }
        //GET: api/GetVehicleModels
        [Route("api/GetVehicleModelsAsync")]
        public async Task<IHttpActionResult> GetVehicleModelsAsync(string search, int? makeId, string sortOrder = "", int? page = 1, int pageSize = 5, string sortBy = "")
        {
            var filter = new FilterParameters
            {
                Search = search,
                MakeId = makeId
            };
            var sort = new SortParameters
            {
                SortBy = sortBy,
                SortOrder = sortOrder
            };
            var pagep = new PageParameters
            {
                Page = (int)page,
                PageSize = pageSize,
            };
            var vmlist = await _vehicleModelService.GetVehicleModelsAsync(sort, filter, pagep);
            return Ok(new
            {
                data = vmlist,
                paggingInfo = vmlist.GetMetaData()
            });
        }

        // GET: api/VehicleModel/5
        [Route("api/GetVehicleModelAsync")]
        [HttpGet]
        [ResponseType(typeof(VehicleModelVM))]
        public async Task<IHttpActionResult> GetVehicleModelAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehicleModel = await _vehicleModelService.GetVehicleModelAsync((int)id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(vehicleModel);
        }

        // PUT: api/VehicleModel/5
        [Route("api/EditVehicleModelAsync")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> EditVehicleModelAsync(int id, VehicleModelVM vehicleModel)
        {
            if (ModelState.IsValid)
            {
                await _vehicleModelService.UpdateVehicleModelAsync(Mapper.Map<VehicleModel>(vehicleModel));
            }
            if (id != vehicleModel.Id)
            {
                return BadRequest();
            }

            if (vehicleModel == null)
            {
                return NotFound();
            }
            return Ok(vehicleModel);
        }


        // POST: api/VehicleModel
        [Route("api/CreateVehicleModelAsync")]
        [HttpPost]
        [ResponseType(typeof(VehicleModelVM))]
        public async Task<IHttpActionResult> CreateVehicleModelAsync(VehicleModelVM vehicleModel)
        {
            if (ModelState.IsValid)
            {
                await _vehicleModelService.AddVehicleModelAsync(Mapper.Map<VehicleModel>(vehicleModel));
                return CreatedAtRoute("DefaultApi", new { id = vehicleModel.Id }, vehicleModel);
            }
            return Ok(vehicleModel);
        }

        // DELETE: api/VehicleModel/5
        [Route("api/DeleteVehicleModelAsync")]
        [HttpDelete]
        [ResponseType(typeof(VehicleModelVM))]
        public async Task<IHttpActionResult> DeleteVehicleModelAsync(int? id)
        {
            VehicleModelVM vehicleModelVM = Mapper.Map<VehicleModelVM>(await _vehicleModelService.GetVehicleModelAsync((int)id));
            if (vehicleModelVM == null)
            {
                return NotFound();
            }
            await _vehicleModelService.DeleteVehicleModelAsync((int)id);
            return Ok(vehicleModelVM);
        }
    }
}
