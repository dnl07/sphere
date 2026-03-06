using Sphere.Domain.Common;

namespace Sphere.Application.Commons.Interfaces {
    public interface IDomainEventHandler<TEvent> where TEvent: IDomainEvent {
        Task HandleAsync(TEvent domainEvent, CancellationToken ct = default);
    }
}
