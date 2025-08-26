using System.Globalization;

namespace Secao9.exercicio_02
{
    class Program
    {
        static void Main2(string[] args)
        {
            int n = int.Parse(GetInput("Enter the number of products: "));
            List<Product> products = new List<Product>();
            while (products.Count() < n)
            {
                Console.WriteLine($"Product #{products.Count() + 1} data:");
                products.Add(NewProduct());
                Console.WriteLine();
            }

            Console.WriteLine("PRICE TAGS:");
            foreach (Product product in products) Console.WriteLine(product.PriceTag);
        }

        static Product NewProduct()
        {
            string type = GetInput("Common, used or imported (c/u/i)? ").ToLower();
            string name = GetInput("Name: ");
            double price = double.Parse(GetInput("Price: "), CultureInfo.InvariantCulture);

            if (type == "u") return new UsedProduct(name, price, GetInput("Manufacture date (DD/MM/YYYY): "));
            else if (type == "i")
            {
                double fees = double.Parse(GetInput("Customs fee: "), CultureInfo.InvariantCulture);
                return new ImportedProduct(name, price, fees);
            }

            return new Product(name, price);
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}