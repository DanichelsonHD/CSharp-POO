using Secao15.Exercicio_exemplo.Entities;

namespace Secao15.Exercicios_exemplo.Predicate
{
    class Program
    {
        static void Main1(string[] args)
        {
            List<Product> list = new List<Product>();

            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            list.RemoveAll(ProductTest);
            foreach(Product x in list) Console.WriteLine(x.ToString());
        }

        public static bool ProductTest(Product x) => x.Price >= 100;
    }
}