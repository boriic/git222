using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Common.Interfaces
{
    public interface IFilterParameters
    {
        string Search { get; set; }
        int? MakeId { get; set; }
    }
}
