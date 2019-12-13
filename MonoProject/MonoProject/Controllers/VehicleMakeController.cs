using AutoMapper;
using MonoProject.Models;
using MonoProject.Service;
using MonoProject.Service.Models.Parameters_Models;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using MonoProject.Service.Services.Common;

namespace MonoProject.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly IVehicleMakeService _vehicleMakeService;
        public VehicleMakeController (IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }

        // GET: VehicleMake
        public async Task <ActionResult> Index(string search, int? page = 1, int pageSize = 5, string sortOrder= "",string sortBy = "")
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentFilter = search;
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentPageSize = pageSize;
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
            var vmlist = await _vehicleMakeService.GetVehicleMakes(sort, filter, pagep);
            var makeVMList = AutoMapper.Mapper.Map<IEnumerable<VehicleMakeVM>>(vmlist);
            return View(new StaticPagedList<VehicleMakeVM>(makeVMList, vmlist.GetMetaData()));
        }

        // GET: VehicleMakes/Details
        public async Task <ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleMake = Mapper.Map<VehicleMakeVM>(await _vehicleMakeService.GetVehicleMake((int)id));
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Create
        [HttpGet]
        public async Task <ActionResult> Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        [HttpPost]
        public async Task <ActionResult> Create([Bind(Include = "Id,Name,Abrv")]VehicleMakeVM vehicleMake)
        {
            if(ModelState.IsValid)
            {
                await _vehicleMakeService.AddVehicleMake(Mapper.Map<VehicleMakeEntity>(vehicleMake));
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Edit
        [HttpGet]
        public async Task <ActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleMake = Mapper.Map<VehicleMakeVM>(await _vehicleMakeService.GetVehicleMake((int)id));
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }
        // POST: VehicleMakes/Edit
        [HttpPost]
        public async Task <ActionResult> Edit([Bind(Include = "Id,Name,Abrv")] VehicleMakeVM vehicleMake)
        {
            if (ModelState.IsValid)
            {
                await _vehicleMakeService.UpdateVehicleMake(Mapper.Map<VehicleMakeEntity>(vehicleMake));
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }
        // GET: VehicleMakes/Delete
        public async Task <ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleMake = Mapper.Map<VehicleMakeVM>(await _vehicleMakeService.GetVehicleMake((int)id));
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }
        // POST: VehicleMakes/Delete
        [HttpPost, ActionName("Delete")]
        public async Task <ActionResult> DeleteConfirmed(int? id)
        {
            var vehicleMake = Mapper.Map<VehicleMakeVM>(await _vehicleMakeService.GetVehicleMake((int)id));
            await _vehicleMakeService.DeleteVehicleMake(Mapper.Map<VehicleMakeEntity>(vehicleMake));
            return RedirectToAction("Index");
        }
    }
}