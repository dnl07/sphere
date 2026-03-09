using Sphere.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Domain.Categories {
    public class Category : Entity {
        public string Name { get; set; }

        #pragma warning disable CS8618
        private Category() { }
        #pragma warning restore CS8618

        public Category(string name) {
            Name = name;
        }
    }
}
