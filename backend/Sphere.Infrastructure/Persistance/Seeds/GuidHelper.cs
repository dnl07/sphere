using System.Security.Cryptography;
using System.Text;

namespace Sphere.Infrastructure.Persistance.Seeds {
    public static class GuidHelper {
        public static Guid FromString(string input) {
            byte[] hash = MD5.HashData(Encoding.UTF8.GetBytes(input));
            return new Guid(hash);
        }
    }
}
