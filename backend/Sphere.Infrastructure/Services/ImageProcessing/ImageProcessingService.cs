using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Sphere.Application.Commons.Interfaces.Services;

namespace Sphere.Infrastructure.Services.ImageProcessing {
    public class ImageProcessingService : IImageProcessingService {
        private readonly ILogger<ImageProcessingService> _logger;

        public ImageProcessingService(ILogger<ImageProcessingService> logger) {
            _logger = logger;
        }

        private void TrimTransparentBackground(Image<Rgba32> image) {
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
        }

        private void SmoothAlphaEdges(Image<Rgba32> image) {
            using var alphaImage = new Image<L8>(image.Width, image.Height);

            image.ProcessPixelRows(alphaImage, (srcAccessor, dstAccessor) => {
                for (int y = 0; y < srcAccessor.Height; y++) {
                    var srcRow = srcAccessor.GetRowSpan(y);
                    var dstRow = dstAccessor.GetRowSpan(y);
                    for (int x = 0; x < srcRow.Length; x++) {
                        dstRow[x] = new L8(srcRow[x].A);
                    }
                }
            });

            alphaImage.Mutate(m => m.GaussianBlur(1.0f));

            image.ProcessPixelRows(alphaImage, (dstAccessor, srcAccessor) => {
                for (int y = 0; y < dstAccessor.Height; y++) {
                    var dstRow = dstAccessor.GetRowSpan(y);
                    var srcRow = srcAccessor.GetRowSpan(y);
                    for (int x = 0; x < dstRow.Length; x++) {
                        dstRow[x].A = srcRow[x].PackedValue;
                    }
                }
            });
        }

        public async Task<byte[]> ProcessImage(byte[] imageBytes, CancellationToken ct) {
            _logger.LogDebug("Processing image, input size: {Size}kb", imageBytes.Length / 1024);

            using var input = new MemoryStream(imageBytes);
            using var image = await Image.LoadAsync<Rgba32>(input, ct);

            _logger.LogDebug("Image loaded: {Width}x{Height}", image.Width, image.Height);

            TrimTransparentBackground(image);

            _logger.LogDebug("After trim: {Width}x{Height}", image.Width, image.Height);

            SmoothAlphaEdges(image);

            image.Mutate(mbox => mbox.Resize(new ResizeOptions {
                Size = new Size(800, 800),
                Mode = ResizeMode.Pad,
                PadColor = Color.Transparent,
                Sampler = KnownResamplers.Lanczos3
            }));

            var output = new MemoryStream();
            
            var encoder = new WebpEncoder {
                Quality = 90,
                Method = WebpEncodingMethod.BestQuality,
                FileFormat = WebpFileFormatType.Lossy
            };  

            await image.SaveAsWebpAsync(output, encoder, ct);

            output.Position = 0;

            var result = output.ToArray();

            _logger.LogDebug("Processing complete, output size: {Size}kb", result.Length / 1024);

            return result;
        }
    }
}
