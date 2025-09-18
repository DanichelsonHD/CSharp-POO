using Secao15.Exercicio_exemplo.Entities;

namespace Secao15.Exercicios_exemplo.Func
{
    class Program
    {
        static void Main3(string[] args)
        {
            List<Product> list = new List<Product>();

            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            Func<Product, string> func = x => x.Name.ToUpper();
            List<string> result = list.Select(func).ToList();
            foreach (String x in result) Console.WriteLine(x.ToString());
        }
    }
}