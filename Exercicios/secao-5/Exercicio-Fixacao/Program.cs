using System;
using System.Globalization;

namespace Secao5
{
    class Program
    {
        static void Main1(string[] args)
        {
            Account account = CreateAccount();

            Console.WriteLine($"\nDados da conta: \n{account}");

            Console.Write("\nEntre um valor para depósito: ");
            account.Deposit(float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
            Console.WriteLine($"Dados da conta atualizados: \n{account}");

            Console.Write("\nEntre um valor para saque: ");
            account.WithDraw(float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
            Console.WriteLine($"Dados da conta atualizados: \n{account}");
        }

        static Account CreateAccount()
        {
            Console.Write("Entre o número da conta: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Entre o titular da conta: ");
            string holdersName = Console.ReadLine();

            Console.Write("Deseja realizar um depósito inicial? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s")
            {
                Console.Write("Entre o valor de depósito inicial: ");
                float intialDeposit = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                return new Account(accountNumber, holdersName, intialDeposit);
            }

            return new Account(accountNumber, holdersName);
        }
    }
}