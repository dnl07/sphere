using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingItems.Commands.Create;
using Sphere.Application.UseCases.ClothingItems.Commands.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Sphere.Application.Commons {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            // Register Dispatcher
            services.AddScoped<IUseCaseDispatcher, UseCaseDispatcher>();

            // Register all use case handlers
            services.AddScoped<IUseCaseHandler<CreateClothingItemCommand, CreateClothingItemResponse>, CreateClothingItemHandler>();
            services.AddScoped<IUseCaseHandler<GetClothingItemQuery, GetClothingItemResponse>, GetClothingItemHandler>();

            return services;
        }
    }
}