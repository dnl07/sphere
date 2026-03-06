using Microsoft.Extensions.DependencyInjection;
using Sphere.Application.Commons.Interfaces;
using Sphere.Domain.Common;

namespace Sphere.Infrastructure.Events {
    public class DomainEventDispatcher : IDomainEventDispatcher {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync(IEnumerable<IDomainEvent> events, CancellationToken ct = default) {
            foreach (var domainEvent in events) {
                var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
                var handlers = _serviceProvider.GetServices(handlerType);

                foreach (var handler in handlers) {
                    var method = handlerType.GetMethod("HandleAsync");
                    if (method != null) {
                        await (Task)method.Invoke(handler, new object[] { domainEvent, ct })!;
                    }
                }
            }
        }
    }
}