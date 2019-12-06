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
using MonoProject.Models;
using AutoMapper;

namespace MonoProject.Controllers
{
    public class VehicleModelController : Controller
    {
        private VehicleModelService service = new VehicleModelService();
        private VehicleMakeService makeService = new VehicleMakeService();
        // GET: VehicleModel
        [HttpGet]
        public ActionResult Index(string search, int? makeId, string sortOrder = "", int? page = 1, int pageSize = 5, string sortBy = "")
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentFilter = search;
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentPageSize = pageSize;
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
            var vmlist = service.GetVehicleModels(sort, filter, pagep);
            ViewBag.vehicleMakes = new List<VehicleMakeEntity>(makeService.GetVehicleMakes(new SortParameters() { SortBy = "", SortOrder = ""}, new FilterParameters() { Search = ""}, new PageParameters() {Page = 1, PageSize = 50}));
            return View(new StaticPagedList<VehicleModelVM>(AutoMapper.Mapper.Map<IEnumerable<VehicleModelVM>>(vmlist), vmlist.GetMetaData()));
        }
        // GET: VehicleModels/Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleModel = Mapper.Map<VehicleModelVM>(service.GetVehicleModel((int)id));
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
            ViewBag.VehicleMakeVMId = new SelectList(makeService.GetVehicleMakes(new SortParameters { SortBy = "", SortOrder = ""}, new FilterParameters { Search = ""}, new PageParameters() { Page = 1, PageSize = 50 }), "Id", "Name");
            return View();
        }
        // POST: VehicleModels/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,Abrv,VehicleMakeVMId")]VehicleModelVM vehicleModel)
        {
            if (ModelState.IsValid)
            {
                service.AddVehicleModel(Mapper.Map<VehicleModelEntity>(vehicleModel));
                return RedirectToAction("Index");
            }            
            return View(vehicleModel);          
        }
        // GET: VehicleModels/Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }        
            var vehicleModel = Mapper.Map<VehicleModelVM>(service.GetVehicleModel((int)id));
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleMakeVMId = new SelectList(makeService.GetVehicleMakes(new SortParameters { SortBy ="", SortOrder =""}, new FilterParameters { Search = "" }, new PageParameters() { Page = 1, PageSize = 50 }), "Id","Name");
            return View(vehicleModel);
        }
        // POST: VehicleModels/Edit
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv,VehicleMakeVMId")]VehicleModelVM vehicleModel)
        {
            if (ModelState.IsValid)
            {
                service.UpdateVehicleModel(Mapper.Map<VehicleModelEntity>(vehicleModel));
                return RedirectToAction("Index");
            }          
            return View(vehicleModel);
        }
        // GET: VehicleModels/Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleModel =Mapper.Map<VehicleModelVM>(service.GetVehicleModel((int)id));
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
            var vehicleModel = Mapper.Map<VehicleModelVM>(service.GetVehicleModel((int)id));
            service.DeleteVehicleModel(Mapper.Map<VehicleModelEntity>(vehicleModel));
            return RedirectToAction("Index");
        }
    }
}