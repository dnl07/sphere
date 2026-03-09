using Sphere.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.Commons.Interfaces.Repository {
    public interface ICategoryRepository {
        Task<Category?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<Category>> GetAllAsync(CancellationToken ct = default);
    }
}
