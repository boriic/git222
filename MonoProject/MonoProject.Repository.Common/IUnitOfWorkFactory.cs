using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Repository.Common
{
   public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
