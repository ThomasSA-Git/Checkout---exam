using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.src
{
    public interface IPriceStrategy
    {
        double CalculatePrice(Product product);
    }
}
