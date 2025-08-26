using System;
using System.Globalization;

namespace Secao9.exercicio_04
{
    class Program
    {
        static void Main4(string[] args)
        {
            int n = int.Parse(GetInput("Enter the number of tax payers: "));
            List<TaxPayer> taxPayers = new List<TaxPayer>();
            while (taxPayers.Count() < n)
            {
                Console.WriteLine($"Tax payer #{taxPayers.Count() + 1} data:");
                taxPayers.Add(NewTaxPayer());
                Console.WriteLine();
            }

            Console.WriteLine("TAXES PAID:");
            double totalTaxes = 0.0;
            foreach (TaxPayer taxPayer in taxPayers)
            {
                Console.WriteLine(taxPayer.ToString());
                totalTaxes += taxPayer.Tax();
            }

            Console.WriteLine($"\nTOTAL TAXES: {totalTaxes:F2}");
        }

        static TaxPayer NewTaxPayer()
        {
            string typeOfTaxPayer = GetInput("Individual or company (i/c)? ").ToLower();
            string name = GetInput("Name: ");
            double anualIncome = double.Parse(GetInput("Anual income: "), CultureInfo.InvariantCulture);
            if (typeOfTaxPayer == "i")
            {
                double healthExpenditures = double.Parse(GetInput("Health expenditures: "), CultureInfo.InvariantCulture);
                return new Individual(name, anualIncome, healthExpenditures);
            }
            else if (typeOfTaxPayer == "c") return new Company(name, anualIncome, int.Parse(GetInput("Number of employees: ")));
            return new Individual("", 0.0, 0.0);
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}