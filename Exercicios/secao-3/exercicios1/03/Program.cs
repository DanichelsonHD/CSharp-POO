using System;
using System.Runtime.InteropServices;

namespace Secao3
{
    class Ex1_3
    {
        static void Main3 (string[] args)
        {
            initialize();
        }

        static void initialize ()
        {
            int[] numbers = new int[4];

            for (int i = 0; i < 4; i++)
            {
                System.Console.Write($"Digite o {i + 1}° número: ");
                int number = int.Parse(Console.ReadLine());
                numbers[i] = number;
            }

            System.Console.WriteLine($"DIFERENCA = {calc_diference(numbers[0], numbers[1], numbers[2], numbers[3])}");
        }

        static int calc_diference (int a, int b, int c, int d)
        {
            return (int)(a * b - c * d);
        }
    }
}