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
}