using Microsoft.EntityFrameworkCore;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Domain.Categories;
using Sphere.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Infrastructure.Repositories {
    public class CategoryRepository : ICategoryRepository {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<Category?> GetByIdAsync(Guid id, CancellationToken ct = default) {
            return await _context.Categories.FindAsync(new object[] { id }, ct);
        }

        public async Task<List<Category>> GetAllAsync(CancellationToken ct = default) {
            return await _context.Categories.ToListAsync(ct);
        }
    }
}
