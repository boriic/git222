using MonoProject.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Common.Parameters_Models
{
    public class FilterParameters : IFilterParameters
    {
        public string Search { get; set; }
        public int? MakeId { get; set; }
    }
}
