using Microsoft.Extensions.DependencyInjection;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.ClothingItem.Commands.Delete;
using Sphere.Application.UseCases.ClothingItems.Commands.Create;
using Sphere.Application.UseCases.ClothingItems.Queries.Get;
using Sphere.Application.UseCases.ClothingItems.Queries.GetAll;
using Sphere.Application.UseCases.Image.Queries.Get;
using Sphere.Application.UseCases.Category.Queries.GetAll;

using Sphere.Application.UseCases.SearchEngine.Command.Search;
using Sphere.Application.UseCases.Inference.Commands.Create;
using Sphere.Application.UseCases.ClothingItem.Commands.Update;
using Sphere.Application.UseCases.ClothingItem.Queries.GetAll;
using Sphere.Application.UseCases.ClothingItem.Commands.Create;

namespace Sphere.Application.Commons {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            // Register Dispatcher
            services.AddScoped<IUseCaseDispatcher, UseCaseDispatcher>();

            // Clothing Item Handlers
            services.AddScoped<IUseCaseHandler<CreateClothingItemCommand, CreateClothingItemResponse>, CreateClothingItemHandler>();
            services.AddScoped<IUseCaseHandler<DeleteClothingItemCommand, DeleteClothingItemResponse>, DeleteClothingItemHandler>();
            services.AddScoped<IUseCaseHandler<UpdateClothingItemCommand, UpdateClothingItemResponse>, UpdateClothingItemHandler>();
            services.AddScoped<IUseCaseHandler<GetClothingItemQuery, GetClothingItemResponse>, GetClothingItemHandler>();
            services.AddScoped<IUseCaseHandler<GetAllClothingItemQuery, GetAllClothingItemResponse>, GetAllClothingItemHandler>();
            services.AddScoped<IUseCaseHandler<GetClothingImageQuery, GetClothingImageResponse>, GetClothingImageHandler>();

            // Category Handlers
            services.AddScoped<IUseCaseHandler<GetAllCategoryQuery, GetAllCategoryResponse>, GetAllCategoryHandler>();

            // Media file Handlers
            services.AddScoped<IUseCaseHandler<GetMediaFileQuery, GetMediaFileResponse>, GetMediaFileHandler>();

            // Search Engine Handlers
            services.AddScoped<IUseCaseHandler<SearchCommand, SearchResponse>, SearchHandler>();

            // Background Remover Handler
            services.AddScoped<IUseCaseHandler<CreateInferenceCommand, CreateInferenceResponse>, CreateInferenceHandler>();

            return services;
        }
    }
}