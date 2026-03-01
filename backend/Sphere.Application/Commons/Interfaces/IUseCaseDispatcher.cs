namespace Sphere.Application.Commons.Interfaces {
    public interface IUseCaseDispatcher {
        public Task<TResponse> Dispatch<TResponse>(IUseCase<TResponse> useCase, CancellationToken ct = default);
    }
}
