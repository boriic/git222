using MonoProject.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Common.Parameters_Models
{
    public class SortParameters : ISortParameters
    {
        public string SortBy { get; set; } 
        public string SortOrder { get; set; }
    }
}
