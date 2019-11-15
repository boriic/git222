using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoProject.Models
{
    public class VehicleModelVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int VehicleMakeVMId { get; set; }

        public virtual List<VehicleMakeVM> VehicleMakeVMs { get; set; }
        public VehicleMakeVM VehicleMakeVM { get; set; }
    }
}