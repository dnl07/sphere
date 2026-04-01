using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Sphere.Application.Commons.Interfaces.Services;

namespace Sphere.Infrastructure.Services.ImageProcessing {
    public class ImageProcessingService : IImageProcessingService {
        private readonly ILogger<ImageProcessingService> _logger;
        public ImageProcessingService(ILogger<ImageProcessingService> logger) {
            _logger = logger;
        }
        public byte[] TrimTransparentBackground(byte[] imageBytes) {
            using var image = Image.Load<Rgba32>(imageBytes);

            int top = 0;
            int bottom = image.Height - 1;
            int left = 0;
            int right = image.Width - 1;

            image.ProcessPixelRows(accessor =>
            {
                // Top
                for (int y = 0; y < accessor.Height; y++) {
                    var pixelRow = accessor.GetRowSpan(y);

                    for (int x = 0; x < pixelRow.Length; x++) {
                        ref Rgba32 pixel = ref pixelRow[x];
                        if (pixelRow[x].A > 0) {
                            top = y; goto FoundTop;
                        }
                    }
                }
                FoundTop:

                // Bottom
                for (int y = accessor.Height - 1; y >= 0; y--) {
                    var pixelRow = accessor.GetRowSpan(y);

                    for (int x = 0; x < pixelRow.Length; x++) {
                        if (pixelRow[x].A > 0) {
                            bottom = y; goto FoundBottom;
                        }
                    }
                }
                FoundBottom:

                // Left
                for (int x = 0; x < accessor.Width; x++) { 
                    for (int y = 0 ; y < accessor.Height; y++) {
                        var pixelRow = accessor.GetRowSpan(y);
                        if (pixelRow[x].A > 0) {
                            left = x; goto FoundLeft;
                        }
                    }
                }
                FoundLeft:

                // Right
                for (int x = accessor.Width - 1; x >= 0; x--) {
                    for (int y = 0; y < accessor.Height; y++) {
                        var pixelRow = accessor.GetRowSpan(y);
                        if (pixelRow[x].A > 0) {
                            right = x; goto FoundRight;
                        }
                    }
                }
                FoundRight:;
            });

            image.Mutate(m => m.Crop(new Rectangle(left, top, right - left + 1, bottom - top + 1)));

            using var outputStream = new MemoryStream();
            image.SaveAsPng(outputStream);
            return outputStream.ToArray();
        }
    }
}
