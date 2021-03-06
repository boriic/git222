﻿using MonoProject.DAL.Entities;
using MonoProject.Repository.Common;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Repository.Module
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleMakeRepository>().To<VehicleMakeRepository>();
            Bind<IVehicleModelRepository>().To<VehicleModelRepository>();
            Bind<IRepository<VehicleMakeEntity>>().To<Repository<VehicleMakeEntity>>();
            Bind<IRepository<VehicleModelEntity>>().To<Repository<VehicleModelEntity>>();
        }
    }
}
