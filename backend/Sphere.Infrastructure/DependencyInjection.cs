using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sphere.Infrastructure.Persistance;
using Sphere.Infrastructure.Repositories;
using Sphere.Application.Commons.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Infrastructure.Events;
using Sphere.Domain.ClothingItems.Events;
using Sphere.Infrastructure.EventHandlers;
using Sphere.Application.Commons.Interfaces.Services;
using Sphere.Infrastructure.Services.SearchEngine;
using Sphere.Infrastructure.Services.FileStorage;

namespace Sphere.Infrastructure {
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddSingleton<IFileStorage, LocalFileStorage>();

            services.AddScoped<IClothingItemRepository, ClothingItemRepository>();

            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
            services.AddScoped<IDomainEventHandler<ClothingItemCreatedEvent>, ClothingItemCreatedEventHandler>();

            // Search Engine Services
            services.AddHttpClient<ISearchEngineService, SearchEngineService>((sp, client) => {
                var config = sp.GetRequiredService<IConfiguration>();
                client.BaseAddress = new Uri(config["SearchEngine:BaseUrl"]!);
                client.Timeout = TimeSpan.FromSeconds(int.Parse(config["SearchEngine:Timeout"] ?? "30"));
            });

            return services;
        }
    }
}
