using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Domain.Clothing.Exceptions {
    public class InvalidClothingException : Exception {
        public InvalidClothingException() { }
        public InvalidClothingException(string message) : base(message) { }
        public InvalidClothingException(string message, Exception innerException) : base(message, innerException) { }
    }
}
