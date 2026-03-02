namespace Sphere.Api.Utils {
    public static class BytesConverter {
        public static byte[] ConvertToBytes(this IFormFile file) {
            if (file.Length <= 0) return [];

            using var ms = new MemoryStream();
            file.CopyTo(ms);
            var fileBytes = ms.ToArray();
            return fileBytes;
        }
    }
}
