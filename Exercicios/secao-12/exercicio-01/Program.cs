using Secao12.exercicio_01.entities;
using Secao12.exercicio_01.services;
using System.Globalization;

namespace Secao12.exercicio_01
{
    class Program
    {
        static void Main1(string[] args)
        {
            int number = int.Parse(GetInput("Enter contract data\nNumber: "));
            DateTime date = DateTime.ParseExact(GetInput("Date (dd/MM/yyyy): "), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            double value = double.Parse(GetInput("Contract value: "), CultureInfo.InvariantCulture);
            Contract contract = new Contract(number, date, value);

            int months = int.Parse(GetInput("Enter number of installments: "));
            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(contract, months);

            Console.WriteLine("Installments:");
            foreach (Installment installment in contract.Installments) Console.WriteLine(installment.ToString());
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}