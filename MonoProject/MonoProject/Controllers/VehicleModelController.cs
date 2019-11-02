using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonoProject.Service;
using PagedList;
using PagedList.Mvc;

namespace MonoProject.Controllers
{
    public class VehicleModelController : Controller
    {
        private VehicleModelService service = new VehicleModelService();
        private VehicleMakeService makeService = new VehicleMakeService();
        // GET: VehicleModel
        public ActionResult Index(string sortOrder, string currentFilter, string search, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }
            if (sortOrder == null)
            {
                sortOrder = "";
            }
            ViewBag.CurrentFilter = search;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(service.GetVehicleModels(search, sortOrder).ToPagedList(pageNumber, pageSize));
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
            ViewBag.VehicleMakeEntityId = new SelectList(makeService.GetVehicleMakes("",""), "Id", "Name");
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
            ViewBag.VehicleMakeEntityId = new SelectList(makeService.GetVehicleMakes("", ""), "Id", "Name");
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