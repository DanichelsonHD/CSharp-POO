using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;

namespace ProvaLogicaDeProgramacao
{
    class Ex3_2
    {
        static void Main2 (string[] args)
        {
            Read_N();
        }

        static void Read_N ()
        {
            System.Console.Write("Digite um número inteiro positivo: ");
            int? n = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                System.Console.Write($"Digite o {i + 1}° número: ");
                int? number_x = int.Parse(Console.ReadLine());

                if (Verify_Number(number_x))
                {
                    count++;
                }
            }

            System.Console.WriteLine($"{count} in\n{n - count} out");
        }

        static bool Verify_Number (int? number_x)
        {
            if (number_x >= 10 && number_x <= 20) { return true; }
            return false;
        }
    }
}