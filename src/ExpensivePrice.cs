using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.src
{
    public class ExpensivePrice : IPriceStrategy
    {
        public double CalculatePrice(Product product)
        {
            return product.Price;
        }
    }
}
