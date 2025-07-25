using System;

namespace Secao3
{
    class Ex3_1
    {
        static void Main1(string[] args)
        {
            ValidatePassword();
        }

        static readonly string password = "2002";

        static void ValidatePassword()
        {
            string input = GetInput();

            while (input != password)
            {
                System.Console.WriteLine("Senha Inválida");
                input = GetInput();
            }

            System.Console.WriteLine("Acesso Permitido");
            return;
        }

        static string GetInput()
        {
            Console.Write("Digite a senha: ");
            return Console.ReadLine();
        }
    }
}