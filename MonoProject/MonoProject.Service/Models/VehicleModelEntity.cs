using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Service
{
    public class VehicleModelEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }


        public int VehicleMakeEntityId { get; set; }
        public VehicleMakeEntity VehicleMakeEntity { get; set; }
    }
}
