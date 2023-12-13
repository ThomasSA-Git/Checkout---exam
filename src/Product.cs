using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.src
{
    public class Product
    {
        public char Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Group { get; set; }
        public bool IsMultiPack { get; set; }
        public int MultiPackSize { get; set; }
        public double MultiPackDiscount { get; set; }
        public bool IsDiscounted { get; set; }
        public int Discount { get; set; }
        public bool IsBottleDeposit { get; set; }

        public static List<Product> CreateListOfProducts()
        {
            List<Product> productList = new List<Product>
        {
            new Product { Code = 'A', Name = "Milk", Price = 10.0, Group = "1", IsMultiPack = true, MultiPackSize = 3, MultiPackDiscount = 3, IsDiscounted = false, Discount = 0, IsBottleDeposit = false },
            new Product { Code = 'B', Name = "Bread", Price = 15.0, Group = "2", IsMultiPack = false, MultiPackSize = 0, IsDiscounted = true, Discount = 5, IsBottleDeposit = false },
            new Product { Code = 'C', Name = "Cheese", Price = 20.0, Group = "1", IsMultiPack = false, MultiPackSize = 0, IsDiscounted = false, Discount = 0, IsBottleDeposit = false },
            new Product { Code = 'D', Name = "Cereal", Price = 12.0, Group = "2", IsMultiPack = false, MultiPackSize = 0, IsDiscounted = false, Discount = 0, IsBottleDeposit = false },
            new Product { Code = 'E', Name = "Yogurt", Price = 8.0, Group = "1", IsMultiPack = false, MultiPackSize = 0, IsDiscounted = false, Discount = 0, IsBottleDeposit = false },
            new Product { Code = 'F', Name = "Eggs", Price = 18.0, Group = "2", IsMultiPack = true, MultiPackSize = 6, MultiPackDiscount = 5.0, IsDiscounted = false, Discount = 0, IsBottleDeposit = false },
            new Product { Code = 'G', Name = "Butter", Price = 25.0, Group = "1", IsMultiPack = false, MultiPackSize = 0, IsDiscounted = false, Discount = 0, IsBottleDeposit = false },
            new Product { Code = 'H', Name = "Jam", Price = 12.0, Group = "2", IsMultiPack = false, MultiPackSize = 0, IsDiscounted = false, Discount = 0, IsBottleDeposit = false },
            new Product { Code = 'I', Name = "Pasta", Price = 10.0, Group = "2", IsMultiPack = false, MultiPackSize = 0, IsDiscounted = true, Discount = 2, IsBottleDeposit = false },
            new Product { Code = 'J', Name = "Tomato Sauce", Price = 15.0, Group = "2", IsMultiPack = false, MultiPackSize = 0, IsDiscounted = true, Discount = 130, IsBottleDeposit = false },
            new Product { Code = 'K', Name = "Chicken", Price = 30.0, Group = "3", IsMultiPack = false, MultiPackSize = 0, IsDiscounted = false, Discount = 0, IsBottleDeposit = false },
            new Product { Code = 'L', Name = "Beef", Price = 40.0, Group = "3", IsMultiPack = false, MultiPackSize = 0, IsDiscounted = false, Discount = 0, IsBottleDeposit = false },
            new Product { Code = 'P', Name = "Bottle Deposit", Price = 2.0, Group = "9", IsMultiPack = false, MultiPackSize = 0, IsDiscounted = false, Discount = 0, IsBottleDeposit = true },
        };

            return productList;
        }
    }
}