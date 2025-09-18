using Secao13.problema_motivador.reuso.services;

namespace Secao13.problema_motivador.reuso
{
    class Program
    {
        static void Main1(string[] args)
        {
            PrintService printService = new PrintService();

            int valuesQuantity = int.Parse(GetInput("How many values? "));
            for (int index = 0; index < valuesQuantity; index++)
            {
                int value = int.Parse(Console.ReadLine());
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