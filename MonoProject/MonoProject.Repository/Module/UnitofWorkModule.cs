using MonoProject.Repository.Common;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Repository.Module
{
    public class UnitofWorkModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWorkFactory>().ToFactory();
            Bind<IUnitOfWork>().To<UnitofWork>();
        }
    }
}
