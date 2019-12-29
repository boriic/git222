using MonoProject.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Model
{
    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }


        public int VehicleMakeId { get; set; }
        public IVehicleMake VehicleMake { get; set; }
    }
}
