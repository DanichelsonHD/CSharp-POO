using System;

namespace Secao3
{
    class Ex1_1
    {
        static void Main1 (string[] args)
        {
            initialize();
        }

        static void initialize ()
        {
            System.Console.Write("Digite um número inteiro: ");
            int? first_number = int.Parse(Console.ReadLine());
            
            System.Console.Write("Digite outro número inteiro: ");
            int? second_number = int.Parse(Console.ReadLine());

            if (first_number == null || second_number == null)
            {
                System.Console.WriteLine("Número inválido");
                return;
            }
            
            System.Console.WriteLine($"SOMA: {Calc_Sum(first_number, second_number)}");
        }

        static int? Calc_Sum (int? first, int? second)
        {
            return first + second;
        }
    }
}