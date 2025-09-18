using Secao13.problema_motivador.performance.services;

namespace Secao13.problema_motivador.performance
{
    class Program
    {
        static void Main2(string[] args)
        {
            PrintService printService = new PrintService();

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