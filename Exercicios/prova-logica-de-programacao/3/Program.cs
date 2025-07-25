using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;

namespace ProvaLogicaDeProgramacao
{
    class Ex3_1
    {
        static void Main1 (string[] args)
        {
            Get_Tries(3);
        }

        static int Verify_Password (string password, string word_tried)
        {
            if (password == word_tried)
            {
                System.Console.WriteLine("Acesso Permitido");
                return 1;
            }
            else
            {
                System.Console.WriteLine("Senha Inválida");
                return 0;
            }
        }

        static void Get_Tries (int max_tries)
        {
            int tries = 0;

            while (tries < max_tries)
            {
                System.Console.Write("Digite a senha: ");
                string? word_tried = Console.ReadLine();
                int result = Verify_Password("2002", word_tried);
                
                if (result == 1) { break;}

                tries++;
                
                if (tries == max_tries) { System.Console.WriteLine("Número máximo de tentativas atingido"); }
            }
        }
    }

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