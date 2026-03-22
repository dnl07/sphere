using Microsoft.Extensions.DependencyInjection;
using Sphere.Application.Commons;
using Sphere.Application.Commons.Interfaces;
using Sphere.Application.UseCases.Categories.Queries.GetAll;
using Sphere.Application.UseCases.ClothingItems.Commands.Create;
using Sphere.Application.UseCases.ClothingItems.Commands.Delete;
using Sphere.Application.UseCases.ClothingItems.Commands.Update;
using Sphere.Application.UseCases.ClothingItems.Commons;
using Sphere.Application.UseCases.ClothingItems.Queries.GetById;
using Sphere.Application.UseCases.ClothingItems.Queries.GetImage;
using Sphere.Application.UseCases.ClothingItems.Queries.GetItems;
using Sphere.Application.UseCases.Inference.Commands.Inference;
using Sphere.Application.UseCases.MediaFiles.Queries.Get;
using Sphere.Application.UseCases.Search.Command.Search;

namespace Sphere.Application {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            // Register Dispatcher
            services.AddScoped<IUseCaseDispatcher, UseCaseDispatcher>();

            // Clothing Item Handlers
            services.AddScoped<IUseCaseHandler<CreateClothingItemCommand, ClothingItemDto>, CreateClothingItemHandler>();
            services.AddScoped<IUseCaseHandler<DeleteClothingItemCommand, DeleteClothingItemResponse>, DeleteClothingItemHandler>();
            services.AddScoped<IUseCaseHandler<UpdateClothingItemCommand, ClothingItemDto>, UpdateClothingItemHandler>();
            services.AddScoped<IUseCaseHandler<GetClothingItemByIdQuery, ClothingItemDto>, GetClothingItemByIdHandler>();
            services.AddScoped<IUseCaseHandler<GetClothingImageQuery, GetClothingImageResponse>, GetClothingImageHandler>();
            services.AddScoped<IUseCaseHandler<GetItemsQuery, GetItemsResponse>, GetItemsHandler>();

            // Category Handlers
            services.AddScoped<IUseCaseHandler<GetAllCategoryQuery, GetAllCategoryResponse>, GetAllCategoryHandler>();

            // Media file Handlers
            services.AddScoped<IUseCaseHandler<GetMediaFileQuery, GetMediaFileResponse>, GetMediaFileHandler>();

            // Search Engine Handlers
            services.AddScoped<IUseCaseHandler<SearchCommand, SearchResponse>, SearchHandler>();

            // Background Remover Handler
            services.AddScoped<IUseCaseHandler<InferenceCommand, InferenceResponse>, InferenceHandler>();

            return services;
        }
    }
}