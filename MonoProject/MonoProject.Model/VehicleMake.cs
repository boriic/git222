using MonoProject.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Model
{
    public class VehicleMake : IVehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual List<IVehicleModel> VehicleModels { get; set; }
        public VehicleMake()
        {
            VehicleModels = new List<IVehicleModel>();
        }
    }
}
