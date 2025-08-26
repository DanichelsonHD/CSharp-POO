namespace Secao10.exercicio_02
{
    class Program
    {
        static void Main2(string[] args)
        {
            try
            {
                Account account = NewAccount;
                Console.WriteLine();

                account.Withdraw(GetInput("Enter amount for withdraw: "));
                Console.WriteLine($"New balance: {account.Balance:F2}");
            }
            catch (WithdrawException e)
            {
                Console.WriteLine($"Withdraw error: {e.Message}");
            }
        }

        static Account NewAccount => new Account(
            GetInput("Enter account data\nNumber: "),
            GetInput("Holder: "),
            GetInput("Initial balance: "),
            GetInput("Withdraw limit: ")
        );

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}