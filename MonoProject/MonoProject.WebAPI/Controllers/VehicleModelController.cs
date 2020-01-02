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
    [RoutePrefix("vehiclemodel")]
    public class VehicleModelController : ApiController
    {
        private readonly IVehicleModelService _vehicleModelService;
        public VehicleModelController(IVehicleModelService vehicleModelService)
        {
            _vehicleModelService = vehicleModelService;
        }
        //GET: api/getvehiclemodels
        [Route("api/getvehiclemodels")]
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

        // GET: api/getvehiclemodel
        [Route("api/getvehiclemodel")]
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

        // PUT: api/updatevehiclemodel
        [Route("api/updatevehiclemodel")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> UpdateVehicleModelAsync(int id, VehicleModelVM vehicleModel)
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


        // POST: api/createvehiclemodel
        [Route("api/createvehiclemodel")]
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

        // DELETE: api/deletevehiclemodel
        [Route("api/deletevehiclemodel")]
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
