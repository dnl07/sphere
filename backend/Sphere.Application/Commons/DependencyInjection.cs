using Microsoft.Extensions.DependencyInjection;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingImage.Queries.Get;
using Sphere.Application.UseCases.ClothingItem.Commands.Delete;
using Sphere.Application.UseCases.ClothingItems.Commands.Create;
using Sphere.Application.UseCases.ClothingItems.Queries.GetAll;
using Sphere.Application.UseCases.SearchEngine.Command.Search;

namespace Sphere.Application.Commons {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            // Register Dispatcher
            services.AddScoped<IUseCaseDispatcher, UseCaseDispatcher>();

            // Register all use case handlers

            // Clothing Item Handlers
            // Commands
            services.AddScoped<IUseCaseHandler<CreateClothingItemCommand, CreateClothingItemResponse>, CreateClothingItemHandler>();
            services.AddScoped<IUseCaseHandler<DeleteClothingItemCommand, DeleteClothingItemResponse>, DeleteClothingItemHandler>();

            // Queries
            services.AddScoped<IUseCaseHandler<GetClothingImageQuery, GetClothingImageResponse>, GetClothingImageHandler>();
            services.AddScoped<IUseCaseHandler<GetAllClothingItemQuery, GetAllClothingItemResponse>, GetAllClothingItemHandler>();

            // Clothing Image Handlers
            services.AddScoped<IUseCaseHandler<GetClothingImageQuery, GetClothingImageResponse>, GetClothingImageHandler>();

            // Search Engine Handlers
            services.AddScoped<IUseCaseHandler<SearchCommand, SearchResponse>, SearchHandler>();

            return services;
        }
    }
}