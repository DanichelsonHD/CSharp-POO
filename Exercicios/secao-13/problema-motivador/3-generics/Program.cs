using Secao13.problema_motivador.generics.services;

namespace Secao13.problema_motivador.generics
{
    class Program
    {
        static void Main3(string[] args)
        {
            PrintService<string> printService = new PrintService<string>();

            int valuesQuantity = int.Parse(GetInput("How many values? "));
            for (int index = 0; index < valuesQuantity; index++)
            {
                string value = Console.ReadLine();
                printService.AddValue(value);
            }
            printService.Print();
            Console.WriteLine($"First: {printService.First()}");
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}