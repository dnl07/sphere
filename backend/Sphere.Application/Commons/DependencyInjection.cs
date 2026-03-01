using Microsoft.Extensions.DependencyInjection;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingItems.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.Commons {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            // Register Dispatcher
            services.AddScoped<IUseCaseDispatcher, UseCaseDispatcher>();

            // Register all use case handlers
            services.AddScoped<IUseCaseHandler<CreateClothingItemCommand, CreateClothingItemResponse>, CreateClothingItemHandler>();

            return services;
        }
    }
}
