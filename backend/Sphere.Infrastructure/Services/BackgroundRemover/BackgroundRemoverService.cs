using Microsoft.Extensions.Logging;
using Sphere.Application.Commons.Interfaces.Services;
using Sphere.Infrastructure.Services.SearchEngine;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace Sphere.Infrastructure.Services.BackgroundRemover {
    internal class BackgroundRemoverService : IBackgroundRemoverService {
        private readonly HttpClient _client;
        private readonly ILogger<BackgroundRemoverService> _logger;

        public BackgroundRemoverService(HttpClient client, ILogger<BackgroundRemoverService> logger) {
            _client = client;
            _logger = logger;
        }

        public async Task<byte[]> RemoveBackgroundAsync(byte[] imageData, CancellationToken ct = default) {
            var url = "inference?model=unet";

            try {
                var requestContent = new MultipartFormDataContent();

                var imageContent = new ByteArrayContent(imageData);
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");

                requestContent.Add(imageContent, "file", "image.png");

                var response = await _client.PostAsync(url, requestContent, ct);

                response.EnsureSuccessStatusCode();

                var zipBytes = await response.Content.ReadAsByteArrayAsync(ct);

                using var stream = new MemoryStream(zipBytes);
                using var archive = new ZipArchive(stream);

                var imageEntry = archive.GetEntry("image.png");

                if (imageEntry is null) {
                    _logger.LogError("Expected image.png in the zip archive but it was not found");
                    throw new FileNotFoundException("Expected image.png in the zip archive but it was not found");
                }

                using var imageStream = imageEntry.Open();
                using var resultStream = new MemoryStream();

                await imageStream.CopyToAsync(resultStream, ct);

                return resultStream.ToArray();
            } catch (Exception e) {
                _logger.LogError(e, "Error occurred while removing background from image");
                throw;
            }
        }
    }
}
