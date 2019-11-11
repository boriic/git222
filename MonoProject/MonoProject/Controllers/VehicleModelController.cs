using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonoProject.Service;
using PagedList;
using PagedList.Mvc;
using MonoProject.Service.Models.Parameters_Models;

namespace MonoProject.Controllers
{
    public class VehicleModelController : Controller
    {
        private VehicleModelService service = new VehicleModelService();
        private VehicleMakeService makeService = new VehicleMakeService();
        // GET: VehicleModel
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
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(service.GetVehicleModels(sort, filter).ToPagedList(pageNumber, pageSize));
        }
        // GET: VehicleModels/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModelEntity vehicleModel = service.GetVehicleModel((int)id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }
        // GET: VehicleModels/Create
        [HttpGet]
        public ActionResult Create ()
        {
            ViewBag.VehicleMakeEntityId = new SelectList(makeService.GetVehicleMakes(new SortParameters { SortBy = "", SortOrder = ""}, new FilterParameters { Search = ""}), "Id", "Name");
            return View();
        }
        // POST: VehicleModels/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,Abrv,VehicleMakeEntityId")]VehicleModelEntity vehicleModel)
        {
            if (ModelState.IsValid)
            {
                service.AddVehicleModel(vehicleModel);
                return RedirectToAction("Index");
            }
            ViewBag.VehicleMakeEntityId = new SelectList(makeService.GetVehicleMakes(new SortParameters { SortBy = "", SortOrder = "" }, new FilterParameters { Search = "" }), "Id", "Name");
            return View(vehicleModel);          
        }
        // GET: VehicleModels/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModelEntity vehicleModel = service.GetVehicleModel((int)id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }
        // POST: VehicleModels/Edit
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv")]VehicleModelEntity vehicleModel)
        {
            if (ModelState.IsValid)
            {
                service.UpdateVehicleModel(vehicleModel);
                return RedirectToAction("Index");
            }
            return View(vehicleModel);
        }
        // GET: VehicleModels/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModelEntity vehicleModel = service.GetVehicleModel((int)id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }
        // POST: VehicleModels/Delete
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed (int? id)
        {
            VehicleModelEntity vehicleModel = service.GetVehicleModel((int)id);
            service.DeleteVehicleModel(vehicleModel);
            return RedirectToAction("Index");
        }
    }
}