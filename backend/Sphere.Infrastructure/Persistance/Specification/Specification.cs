using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Infrastructure.Persistance.Specification {
    public abstract class Specification<T> {
        public abstract IQueryable<T> Apply(IQueryable<T> query);
    }
}
