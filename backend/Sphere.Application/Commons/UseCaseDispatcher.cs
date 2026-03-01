using Sphere.Application.Commons.Interfaces;

namespace Sphere.Application.Commons {
    public class UseCaseDispatcher : IUseCaseDispatcher {
        private readonly IServiceProvider _serviceProvider;

        public UseCaseDispatcher(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Dispatch<TResponse>(IUseCase<TResponse> useCase, CancellationToken ct = default) {
            var handlerType = typeof(IUseCaseHandler<,>).MakeGenericType(useCase.GetType(), typeof(TResponse));

            var handlerObj = _serviceProvider.GetService(handlerType);

            if (handlerObj is null) {
                throw new InvalidOperationException($"No handler found for use case of type {useCase.GetType().Name}");
            }

            dynamic handler = handlerObj;

            return await handler.Handle((dynamic)useCase, ct);
        }
    }
}
