using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.src
{
    public class BottleDepositStrategy : IBottleDepositStrategy
    {
        public double ApplyBottleDeposit(Product product, double totalPrice)
        {
            if (product.IsBottleDeposit)
            {
                totalPrice += product.Price; // Add the price of the bottle deposit
            }
            return totalPrice;
        }
    }
}
