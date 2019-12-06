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

namespace MonoProject.Controllers
{
    public class VehicleMakeController : Controller
    {
        private VehicleMakeService service = new VehicleMakeService();

        // GET: VehicleMake
        public ActionResult Index(string search, int? page = 1, int pageSize = 5, string sortOrder= "",string sortBy = "")
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
            var vmlist = service.GetVehicleMakes(sort, filter, pagep);
            var makeVMList = AutoMapper.Mapper.Map<IEnumerable<VehicleMakeVM>>(vmlist);
            return View(new StaticPagedList<VehicleMakeVM>(makeVMList, vmlist.GetMetaData()));
        }

        // GET: VehicleMakes/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleMake = Mapper.Map<VehicleMakeVM>(service.GetVehicleMake((int)id));
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,Abrv")]VehicleMakeVM vehicleMake)
        {
            if(ModelState.IsValid)
            {
                service.AddVehicleMake(Mapper.Map<VehicleMakeEntity>(vehicleMake));
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleMake = Mapper.Map<VehicleMakeVM>(service.GetVehicleMake((int)id));
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }
        // POST: VehicleMakes/Edit
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv")] VehicleMakeVM vehicleMake)
        {
            if (ModelState.IsValid)
            {
                service.UpdateVehicleMake(Mapper.Map<VehicleMakeEntity>(vehicleMake));
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }
        // GET: VehicleMakes/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleMake = Mapper.Map<VehicleMakeVM>(service.GetVehicleMake((int)id));
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }
        // POST: VehicleMakes/Delete
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            var vehicleMake = Mapper.Map<VehicleMakeVM>(service.GetVehicleMake((int)id));
            service.DeleteVehicleMake(Mapper.Map<VehicleMakeEntity>(vehicleMake));
            return RedirectToAction("Index");
        }
    }
}