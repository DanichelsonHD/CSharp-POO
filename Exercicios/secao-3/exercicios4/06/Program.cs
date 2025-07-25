using System;

namespace Secao3
{
    class Ex4_6
    {
        static void Main6(string[] args)
        {
            Console.Write("Digite um número: ");
            int number = int.Parse(Console.ReadLine());
            Get_Divisors(number);
        }

        static int[] Get_Divisors(int number)
        {
            List<int> divisors = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                    System.Console.WriteLine(i);
                }
            }
            System.Console.WriteLine($"Total de divisores: {divisors.Count}");
            return divisors.ToArray();
        }
    }
}