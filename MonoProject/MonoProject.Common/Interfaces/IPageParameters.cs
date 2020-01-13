using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Common.Interfaces
{
    public interface IPageParameters
    {
        int PageSize { get; set; }
        int Page { get; set; }
    }
}
