using Microsoft.EntityFrameworkCore;
using Sphere.Api.Middleware;
using Sphere.Application.Commons;
using Sphere.Infrastructure;
using Sphere.Infrastructure.Persistance;
using Sphere.Infrastructure.Services.SearchEngine;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Json serialization options
builder.Services
    .AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.DictionaryKeyPolicy = null;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// CORS configuration
builder.Services.AddCors(options => {
    options.AddPolicy("AllowFrontend", policy => {
        policy.
            WithOrigins("http://localhost:5173", "http://frontend:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

await SearchEngineInitializer.InitializeAsync(app.Services);

// Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
