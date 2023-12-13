using Checkout.src;
using System;

class Program
{
    static void Main()
    {
        Scanner scanner = new Scanner();
        PriceCalculator priceCalculator = new PriceCalculator();

        // I subscribe to the events here
        scanner.ProductScanned += priceCalculator.HandleProductScanned;
        priceCalculator.PriceChanged += total => Console.WriteLine($"Total Price: {total:C}");

        Console.WriteLine("Scan products (enter product codes (ABCDEF):");

        while (true)
        {
            string input = Console.ReadLine()?.ToUpper() ?? string.Empty;

            if (string.IsNullOrEmpty(input))
            {
                priceCalculator.PrintReceipt();
                break; // Exit the loop if Enter is pressed without input
            }
            else
            {
                // Scan the products entered in console
                scanner.ScanProducts(input);
            }
        }
    }
}