using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.src
{
    public class Scanner
    {
        public delegate void ScanEventHandler(char productCode);
        public event ScanEventHandler ProductScanned;

        // Method to simulate scanning products with a delay
        public void ScanProducts(string products)
        {
            foreach (char productCode in products)
            {
                System.Threading.Thread.Sleep(500); // Simulate delay
                ProductScanned?.Invoke(productCode);
            }
        }
    }
}