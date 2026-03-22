using Sphere.Application.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.ClothingItem.Commons {
    public class ClothingItemFilter : PagedFilter {
        public Guid[]? CategoryIds { get; set; }
        public string[]? Colors { get; set; }
        public string[]? Sizes { get; set; }
        public string[]? Materials { get; set; }
    }
}
