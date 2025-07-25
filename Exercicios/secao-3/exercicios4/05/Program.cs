using System;

namespace Secao3
{
    class Ex4_5
    {
        static void Main5(string[] args)
        {
            Console.Write("Digite um número: ");
            int number = int.Parse(Console.ReadLine());
            System.Console.WriteLine(Get_Factorial(number));
        }

        static int Get_Factorial(int number)
        {
            if (number == 0 || number == 1) return 1;
            int factorial = 1;
            for (int i = 2; i <= number; i++) factorial *= i;
            return factorial;
        }
    }
}