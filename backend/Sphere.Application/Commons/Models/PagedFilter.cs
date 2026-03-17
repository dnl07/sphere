using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.Commons.Models {
    public class PagedFilter {
        public bool FetchAll { get; set; } = false;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? FromPage { get; set; }
        public int? ToPage { get; set; }
    }
}
