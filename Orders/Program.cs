using System;
using System.Linq;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> output = new Dictionary<string, List<double>>();
            string command = Console.ReadLine();
            while (command != "buy")
            {
                string[] currentProduct = command.Split(" ");
                string productName = currentProduct[0];
                double productPrice = double.Parse(currentProduct[1]);
                double productQuantity = double.Parse(currentProduct[2]);
                if (!output.ContainsKey(productName))
                {
                    List<double> priceAndQuantity = new List<double> { productPrice, productQuantity };
                    output.Add(productName, priceAndQuantity);
                }
                else
                {
                    output[productName][0] = productPrice;
                    output[productName][1] += productQuantity;
                }
                command = Console.ReadLine();
            }
            foreach (var item in output)
            {
                Console.WriteLine($"{item.Key} -> {(item.Value[0] * item.Value[1]):F2}");
            }
        }
    }
}
