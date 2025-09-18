using Secao15.Exercicio_exemplo.Entities;

namespace Secao15.Exercicios_exemplo.Action
{
    class Program
    {
        static void Main2(string[] args)
        {
            List<Product> list = new List<Product>();

            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            Action<Product> act = x => x.Price *= 1.1;
            list.ForEach(act);
            foreach (Product x in list) Console.WriteLine(x.ToString());
        }
    }
}