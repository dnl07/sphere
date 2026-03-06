using Sphere.Domain.Common;

namespace Sphere.Application.Commons.Interfaces {
    public interface IDomainEventDispatcher {
        Task DispatchAsync(IEnumerable<IDomainEvent> events, CancellationToken ct = default);
    }
}
