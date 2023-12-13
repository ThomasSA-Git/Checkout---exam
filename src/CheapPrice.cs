using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.src
{
    public class CheapPrice : IPriceStrategy
    {
        public double CalculatePrice(Product product)
        {
            double discountedPrice = product.Price * (1 - product.Discount / 100.0);
            return discountedPrice;
        }
    }
}
