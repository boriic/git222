using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoProject.Models
{
    public class VehicleMakeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }


        public virtual List<VehicleModelVM> VehicleModelVMs { get; set; }
        public VehicleMakeVM()
        {
            VehicleModelVMs = new List<VehicleModelVM>();
        }
    }
}