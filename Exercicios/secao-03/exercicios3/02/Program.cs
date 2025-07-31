using System;

namespace Secao3
{
    class Ex3_2
    {
        static void Main2(string[] args)
        {
            ValidateCoordinates();
        }

        static void ValidateCoordinates()
        {
            (int x, int y) = GetCoordinates();

            while (x != 0 && y != 0)
            {
                if (x > 0 && y > 0) System.Console.WriteLine("Primeiro");
                if (x < 0 && y > 0) System.Console.WriteLine("Segundo");
                if (x < 0 && y < 0) System.Console.WriteLine("Terceiro");
                if (x > 0 && y < 0) System.Console.WriteLine("Quarto");

                (x, y) = GetCoordinates();
            }
        }

        static (int, int) GetCoordinates()
        {
            Console.Write("Digite um número: ");
            string[] coordinates = Console.ReadLine().Split(' ');
            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);

            return (x, y);
        }
    }
}