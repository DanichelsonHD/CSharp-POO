using System;

namespace Secao3
{
    class Ex04_01
    {
        static void Main1(string[] args)
        {
            Console.Write("Digite um número: ");
            int number = int.Parse(Console.ReadLine());
            int[] oddNumbers = Get_Odd_Numbers(number);
        }

        static int[] Get_Odd_Numbers(int number)
        {
            int[] oddNumbers = new int[number];

            if (number >= 1 && number <= 1000)
            {
                for (int i = 0, count = 1; count <= number; i++, count += 2)
                {
                    System.Console.WriteLine(count);
                    oddNumbers[i] = count;
                }
            }

            return oddNumbers;
        }
    }
}