using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sphere.Infrastructure.Persistance;
using Sphere.Infrastructure.Repositories;
using Sphere.Application.Commons.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Sphere.Infrastructure {
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IClothingItemRepository, ClothingItemRepository>();

            return services;
        }
    }
}
