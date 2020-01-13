using MonoProject.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Common.Parameters_Models
{
    public class PageParameters : IPageParameters
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
