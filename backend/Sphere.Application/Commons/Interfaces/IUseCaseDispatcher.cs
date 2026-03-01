using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.Commons.Interfaces {
    public interface IUseCaseDispatcher {
        public Task<TResponse> Dispatch<TResponse>(IUseCase<TResponse> useCase, CancellationToken ct = default);
    }
}
