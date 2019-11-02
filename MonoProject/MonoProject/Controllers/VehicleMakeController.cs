using MonoProject.Service;
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
            return View(service.GetVehicleMakes(search, sortOrder).ToPagedList(pageNumber, pageSize));
        }

        // GET: VehicleMakes/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeEntity vehicleMake = service.GetVehicleMake((int)id);
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
        public ActionResult Create([Bind(Include = "Id,Name,Abrv")]VehicleMakeEntity vehicleMake)
        {
            if(ModelState.IsValid)
            {
                service.AddVehicleMake(vehicleMake);
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
            VehicleMakeEntity vehicleMake = service.GetVehicleMake((int)id);
            if(vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }
        // POST: VehicleMakes/Edit
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv")] VehicleMakeEntity vehicleMake)
        {
            if (ModelState.IsValid)
            {
                service.UpdateVehicleMake(vehicleMake);
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
            VehicleMakeEntity vehicleMake = service.GetVehicleMake((int)id);
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
            VehicleMakeEntity vehicleMake = service.GetVehicleMake((int)id);
            service.DeleteVehicleMake(vehicleMake);
            return RedirectToAction("Index");
        }
    }
}