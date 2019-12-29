using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Model.Common
{
    public interface IVehicleModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        int VehicleMakeId { get; set; }
        IVehicleMake VehicleMake { get; set; }
    }
}
