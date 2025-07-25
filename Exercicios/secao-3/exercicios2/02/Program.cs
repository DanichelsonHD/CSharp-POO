using System;

namespace Secao3
{
    class Ex2_2
    {
        static void Main2(string[] args)
        {
            bool result = false;

            while (!result)
            {
                Console.Write("Digite um número: ");
                int number = int.Parse(Console.ReadLine());
                result = IsEven(number);
            }
        }

        static bool IsEven (int number)
        {
            if (number % 2 == 0)
            {
                System.Console.WriteLine("PAR");
                return true;
            }
            else
            {
                System.Console.WriteLine("ÍMPAR");
                return false;
            }
        }
    }
}