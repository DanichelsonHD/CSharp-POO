using System;

namespace Secao3
{
    class Ex2_3
    {
        static void Main3(string[] args)
        {
            Console.Write("Digite dois números inteiros: ");
            string[] numbers = Console.ReadLine().Split(' ');
            int number1 = int.Parse(numbers[0]);
            int number2 = int.Parse(numbers[1]);
            bool areMultiples = IsMultiple(number1, number2);
        }

        static bool IsMultiple(int n1, int n2)
        {
            if (n1 % n2 == 0 || n2 % n1 == 0)
            {
                System.Console.WriteLine("São Múltiplos");
                return true;
            }
            else
            {
                System.Console.WriteLine("Não são Múltiplos");
                return false;
            }
        }
    }
}