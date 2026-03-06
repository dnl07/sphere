namespace Sphere.Domain.Common {
    public interface IDomainEvent {
        DateTime OccuredAt { get; }
    }
}
