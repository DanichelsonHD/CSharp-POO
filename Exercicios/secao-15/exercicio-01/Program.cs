using Secao15.Exercicio_01.Entities;
using System.Globalization;
using System.Linq;

namespace Secao15.Exercicio_01
{
    class Program
    {
        static void Main1(string[] args)
        {
            string path = @"..\..\..\Exercicios\secao-15\exercicio-01\in.txt";
            List<Product> products = new List<Product>();
            double averagePrice = 0;

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    products.Add(new Product(line[0], line[1]));
                }
            }

            averagePrice = products.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            List<string> lessThanAverage = products.Where(p => p.Price < averagePrice).OrderByDescending(p => p.Name).Select(p => p.Name).ToList();
            Console.WriteLine($"Average Price: {averagePrice.ToString("F2", CultureInfo.InvariantCulture)}");
            foreach(string str in lessThanAverage) Console.WriteLine(str);
        }
    }
}