using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.Commons.Interfaces.Repository;
using Sphere.Application.Commons.Interfaces.Services;
using Sphere.Domain.ClothingItems.Events;
using Sphere.Infrastructure.Events;
using Sphere.Infrastructure.Events.Handlers;
using Sphere.Infrastructure.Persistance;
using Sphere.Infrastructure.Repositories;
using Sphere.Infrastructure.Services.BackgroundRemover;
using Sphere.Infrastructure.Services.FileStorage;
using Sphere.Infrastructure.Services.SearchEngine;

namespace Sphere.Infrastructure {
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddSingleton<IFileStorage, LocalFileStorage>();

            // Repositories
            services.AddScoped<IClothingItemRepository, ClothingItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            // Domain Event Services
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
            services.AddScoped<IDomainEventHandler<ClothingItemCreatedEvent>, ClothingItemCreatedEventHandler>();
            services.AddScoped<IDomainEventHandler<ClothingItemDeletedEvent>, ClothingItemDeletedEventHandler>();

            // Search Engine Service
            services.AddHttpClient<ISearchEngineService, SearchEngineService>((sp, client) => {
                var config = sp.GetRequiredService<IConfiguration>();
                client.BaseAddress = new Uri(config["SearchEngine:BaseUrl"]!);
                client.Timeout = TimeSpan.FromSeconds(int.Parse(config["SearchEngine:Timeout"] ?? "30"));
            });

            // Background Remover Service
            services.AddHttpClient<IBackgroundRemoverService, BackgroundRemoverService>((sp, client) => {
                var config = sp.GetRequiredService<IConfiguration>();
                client.BaseAddress = new Uri(config["BackgroundRemover:BaseUrl"]!);
                client.Timeout = TimeSpan.FromSeconds(int.Parse(config["BackgroundRemover:Timeout"] ?? "30"));
            });

            return services;
        }
    }
}
