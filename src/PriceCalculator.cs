using System;
using System.Collections.Generic;
using System.Linq; // LINQ is used
using System.Text;
using System.Threading.Tasks;

namespace Checkout.src
{
    public class PriceCalculator
    {
        private List<Product> scannedProducts = new List<Product>();

        // Delegate for notifying price changes
        public delegate void PriceChangedEventHandler(double totalPrice);
        public event PriceChangedEventHandler PriceChanged;

        // Price strategies
        private IPriceStrategy cheapPriceStrategy = new CheapPrice(); // Interface IPriceStrategy
        private IPriceStrategy expensivePriceStrategy = new ExpensivePrice(); // Interface IPriceStrategy
        private IBottleDepositStrategy bottleDepositStrategy = new BottleDepositStrategy(); // Interface IBottleDepositStrategy

        // Method to handle scanned products
        public void HandleProductScanned(char productCode)
        {
            Product product = GetProductByCode(productCode);
            scannedProducts.Add(product);

            double totalPrice = CalculateTotalPrice();
            PriceChanged?.Invoke(totalPrice);
        }

        // Get product by code
        private Product GetProductByCode(char code)
        {
            List<Product> productList = Product.CreateListOfProducts();
            Product foundProduct = productList.Find(p => p.Code == code);
            return foundProduct ?? new Product { Code = '0', Name = "Unknown", Price = 0.0, IsDiscounted = false, IsBottleDeposit = false };
        }

        // Calculate total price based on the scanned products
        private double CalculateTotalPrice()
        {
            double totalPrice = 0;

            // LINQ GroupBy is used here
            var groupedProducts = scannedProducts.GroupBy(p => new { p.Code, p.Group });

            foreach (var group in groupedProducts)
            {
                var product = group.First();
                int quantity = group.Count();

                double itemPrice = 0;

                if (product.IsMultiPack && quantity >= product.MultiPackSize)
                {
                    itemPrice = quantity * (product.Price - product.MultiPackDiscount);
                }
                else
                {
                    IPriceStrategy priceStrategy = product.IsDiscounted ? cheapPriceStrategy : expensivePriceStrategy;
                    itemPrice = quantity * priceStrategy.CalculatePrice(product);
                }

                totalPrice += itemPrice;
                totalPrice = bottleDepositStrategy.ApplyBottleDeposit(product, totalPrice);
            }

            return totalPrice;
        }

        //for printing receipt after empty input in console
        public void PrintReceipt()
        {
            Console.WriteLine("Scanned Products:");

            foreach (var group in scannedProducts.GroupBy(p => p.Code))
            {
                var product = group.First();
                int quantity = group.Count();

                Console.WriteLine($"{product.Name} (Code: {product.Code}) - Quantity: {quantity} - Price: {CalculateProductPrice(product, quantity):C}");
            }

            double totalPrice = CalculateTotalPrice();
            Console.WriteLine($"Total Price: {totalPrice:C}");
        }

        // only used for printReceipt
        private double CalculateProductPrice(Product product, int quantity)
        {
            double itemPrice = 0;

            if (product.IsMultiPack && quantity >= product.MultiPackSize)
            {
                itemPrice = quantity * (product.Price - product.MultiPackDiscount);
            }
            else
            {
                IPriceStrategy priceStrategy = product.IsDiscounted ? cheapPriceStrategy : expensivePriceStrategy;
                itemPrice = quantity * priceStrategy.CalculatePrice(product);
            }

            itemPrice = bottleDepositStrategy.ApplyBottleDeposit(product, itemPrice);
            return itemPrice;
        }
    }
}