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
        public ActionResult Index(string sortOrder, string sortBy, string search, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentFilter = search;
            ViewBag.CurrentSortBy = sortBy;
            var filter = new FilterParameters
            {
                Search = search
            };
            var sort = new SortParameters
            {
                SortBy = sortBy,
                SortOrder = sortOrder
            };
            if (sort.SortBy == null)
            {
                sort.SortBy = "";
            }
            if (sort.SortOrder == null)
            {
                sort.SortOrder = "";
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var vmList = global::AutoMapper.Mapper.Map<List<VehicleMakeVM>>(service.GetVehicleMakes(sort, filter));
            return View(vmList.ToPagedList(pageNumber, pageSize));
        }

        // GET: VehicleMakes/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleMake = global::AutoMapper.Mapper.Map<VehicleMakeVM>(service.GetVehicleMake((int)id));
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
                service.AddVehicleMake(global::AutoMapper.Mapper.Map<VehicleMakeEntity>(vehicleMake));
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Edit
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleMake = global::AutoMapper.Mapper.Map<VehicleMakeVM>(service.GetVehicleMake((int)id));
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
                service.UpdateVehicleMake(global::AutoMapper.Mapper.Map<VehicleMakeEntity>(vehicleMake));
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
            var vehicleMake = global::AutoMapper.Mapper.Map<VehicleMakeVM>(service.GetVehicleMake((int)id));
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
            var vehicleMake = global::AutoMapper.Mapper.Map<VehicleMakeVM>(service.GetVehicleMake((int)id));
            service.DeleteVehicleMake(global::AutoMapper.Mapper.Map<VehicleMakeEntity>(vehicleMake));
            return RedirectToAction("Index");
        }
    }
}