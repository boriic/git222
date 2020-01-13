using System;
using System.Collections.Generic;
using System.Text;

namespace MonoProject.Common.Interfaces
{
    public interface ISortParameters
    {
        string SortBy { get; set; }
        string SortOrder { get; set; }
    }
}
