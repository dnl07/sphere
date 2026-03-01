namespace Sphere.Application.Commons.Interfaces {
    public interface IUseCaseHandler<TUseCase, TResponse> 
        where TUseCase : IUseCase<TResponse> {
        Task<TResponse> Handle(TUseCase useCase, CancellationToken ct = default);
    }
}
