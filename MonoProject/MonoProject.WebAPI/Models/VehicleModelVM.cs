using MonoProject.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mono.Project.WebAPI.Models
{
    public class VehicleModelVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int VehicleMakeVMId { get; set; }

        public ShortVehicleMakeVM VehicleMakeVM { get; set; }
    }
}