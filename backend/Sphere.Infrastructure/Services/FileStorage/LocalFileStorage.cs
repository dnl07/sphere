using Microsoft.Extensions.Configuration;
using Sphere.Application.Commons.Interfaces;

namespace Sphere.Infrastructure.Services.FileStorage {
    public class LocalFileStorage : IFileStorage {
        private readonly string _basePath;

        public LocalFileStorage(IConfiguration config) {
            _basePath = config["FILE_STORAGE_PATH"] ?? Path.Combine(Directory.GetCurrentDirectory(), "uploads");

            if (!Directory.Exists(_basePath)) {
                Directory.CreateDirectory(_basePath);
            }
        }

        public async Task<bool> SaveAsync(Guid imageId, byte[] fileContent, CancellationToken ct = default) {
            string filePath = Path.Combine(_basePath, imageId.ToString());
            await File.WriteAllBytesAsync(filePath, fileContent, ct);

            if (File.Exists(filePath)) {
                return true;
            }
            return false;
        }
         
        public async Task<byte[]> GetAsync(Guid key, CancellationToken ct = default) {
            string filePath = Path.Combine(_basePath, key.ToString());

            if (!File.Exists(filePath)) {
                throw new FileNotFoundException("File not found", key.ToString());
            }
            return await File.ReadAllBytesAsync(filePath, ct);
        }

        public Task DeleteAsync(Guid key, CancellationToken ct = default) {
            var id = key.ToString();

            if (File.Exists(id)) {
                File.Delete(id);
            }
            return Task.CompletedTask;
        }
    }
}