using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces;

namespace Sphere.Infrastructure.Services.FileStorage {
    public class LocalFileStorage : IFileStorage {
        private readonly string _basePath;
        private readonly ILogger<LocalFileStorage> _logger;

        public LocalFileStorage(IConfiguration config, ILogger<LocalFileStorage> logger) {
            _basePath = config["FILE_STORAGE_PATH"] ?? Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            _logger = logger;

            if (!Directory.Exists(_basePath)) {
                try {
                    Directory.CreateDirectory(_basePath);
                    _logger.LogInformation("Created file storage directory at {BasePath}", _basePath);
                } catch (Exception e) {
                    _logger.LogError(e, "Failed to create file storage directory at {BasePath}", _basePath);
                    throw;
                }
            }
        }

        public async Task SaveAsync(Guid imageId, byte[] fileContent, CancellationToken ct = default) {
            string filePath = GetFilePath(imageId);
            try {
                await File.WriteAllBytesAsync(filePath, fileContent, ct);
            } catch (Exception e) {
                _logger.LogError(e, "Failed to save file with ID {ImageId} at path {FilePath}", imageId, filePath);
                throw;
            }

            if (File.Exists(filePath)) {
                _logger.LogInformation("File saved successfully with ID {ImageId}", imageId);
            } else {
                _logger.LogError("Failed to save file with ID {ImageId}", imageId);
            }
        }
         
        public async Task<byte[]> GetAsync(Guid imageId, CancellationToken ct = default) {
            string filePath = GetFilePath(imageId);

            if (!File.Exists(filePath)) {
                throw new FileNotFoundException("File not found", imageId.ToString());
            }
            return await File.ReadAllBytesAsync(filePath, ct);
        }

        public Task DeleteAsync(Guid imageId, CancellationToken ct = default) {
            string filePath = GetFilePath(imageId);

            if (File.Exists(filePath)) {
                File.Delete(filePath);
                _logger.LogInformation("File deleted successfully with ID {ImageId}", imageId);
            } else {
                _logger.LogWarning("File with ID {ImageId} not found. Skipping deletion.", imageId);
            }
            return Task.CompletedTask;
        }

        private string GetFilePath(Guid key) => Path.Combine(_basePath, key.ToString());
    }
}