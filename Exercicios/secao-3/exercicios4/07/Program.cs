using System;

namespace Secao3
{
    class Ex4_7
    {
        static void Main7(string[] args)
        {
            Console.Write("Digite um número: ");
            int number = int.Parse(Console.ReadLine());
            Show_Exponents(number);
        }

        static void Show_Exponents(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                System.Console.WriteLine($"{i} {(int)Math.Pow(i, 2)} {(int)Math.Pow(i, 3)}");
            }
        }
    }
}