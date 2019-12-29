using Mono.Project.WebAPI.Controllers;
using MonoProject.DAL.Entities;
using MonoProject.Model;
using MonoProject.Model.Common;
using MonoProject.Repository;
using MonoProject.Repository.Common;
using MonoProject.Service;
using MonoProject.Service.Common;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Mono.Project.WebAPI.Module
{
    public class MyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            Bind<IVehicleMakeService>().To<VehicleMakeService>();
            Bind<IVehicleModelService>().To<VehicleModelService>();
            Bind<IVehicleMakeRepository>().To<VehicleMakeRepository>();
            Bind<IVehicleModelRepository>().To<VehicleModelRepository>();
            Bind<IUnitOfWorkFactory>().ToFactory();
            Bind<IUnitOfWork>().To<UnitofWork>();
        }
    }

}
