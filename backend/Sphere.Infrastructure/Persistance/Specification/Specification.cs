namespace Sphere.Infrastructure.Persistance.Specification {
    public abstract class Specification<T> {
        public abstract IQueryable<T> Apply(IQueryable<T> query);
    }
}
