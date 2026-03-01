using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Domain.Clothing.ValueObjects {
    public class Price {
        public decimal Amount { get; }
        public string Currency { get; }

        public Price(decimal amount, string currency) {
            if (amount < 0) {
                throw new ArgumentException("Price cannot be negative.");
            }

            if (string.IsNullOrWhiteSpace(currency)) {
                throw new ArgumentException("Currency cannot be empty.");
            }
            Amount = amount;
            Currency = currency;
        }
    }
}
