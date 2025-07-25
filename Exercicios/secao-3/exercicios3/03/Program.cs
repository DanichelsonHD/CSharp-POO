using System;

namespace Secao3
{
    class Ex3_3
    {
        static void Main3(string[] args)
        {
            GetInput();
        }

        static readonly string[] fuelTypes = ["Álcool", "Gasolina", "Diesel", "Fim"];
        static int[] fuelCount = new int[fuelTypes.Length - 1];
        static void GetInput()
        {
            System.Console.WriteLine("Informe o código do combustível (1-Álcool, 2-Gasolina, 3-Diesel, 4-Fim): ");
            int input = int.Parse(Console.ReadLine());
            while (input != 4)
            {
                if (input < 1 || input > 4)
                {
                    System.Console.WriteLine("Código inválido, tente novamente.");
                    input = int.Parse(Console.ReadLine());
                    continue;
                }
                fuelCount[input - 1]++;
                input = int.Parse(Console.ReadLine());
            }
            PrintFuelTypes();
        }
        static void PrintFuelTypes()
        {
            System.Console.WriteLine("MUITO OBRIGADO!");
            foreach (string fuelType in fuelTypes)
            {
                if (fuelType == "Fim") break;
                System.Console.WriteLine($"{fuelType}: {fuelCount[Array.IndexOf(fuelTypes, fuelType)]}");
            }
        }
    }
}