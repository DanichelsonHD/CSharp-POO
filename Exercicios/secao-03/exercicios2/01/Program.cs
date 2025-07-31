using System;

namespace Secao3
{
    class Ex2_1
    {
        static void Main1(string[] args)
        {
            System.Console.Write("Digite um número inteiro: ");
            int number = int.Parse(Console.ReadLine());
            char result = Verify_Negative(number);
        }

        static char Verify_Negative(int number)
        {
            if (number < 0)
            {
                System.Console.WriteLine("NEGATIVO");
                return '-';
            }
            else
            {
                System.Console.WriteLine("NÃO NEGATIVO");
                return '+';
            }
        }
    }
}