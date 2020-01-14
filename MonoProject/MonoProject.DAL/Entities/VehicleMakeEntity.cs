using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace MonoProject.DAL.Entities
{
    public class VehicleMakeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }


        public virtual List<VehicleModelEntity> VehicleModelEntities { get; set; }
        public VehicleMakeEntity()
        {
            VehicleModelEntities = new List<VehicleModelEntity>();
        }
    }
}
