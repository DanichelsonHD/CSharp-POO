using System.Globalization;

namespace Secao8.exercicio_01
{
    class Program
    {
        static void Main1(string[] args)
        {
            string departmentName = GetInput("Enter department's name: ");
            Console.WriteLine("Enter worker data:");
            Worker worker = new Worker(
                departmentName,
                GetInput("Name: "),
                GetInput("Level (Junior/MidLevel/Senior): "),
                double.Parse(GetInput("Base salary: "), CultureInfo.InvariantCulture)
            );

            int NumberOfContracts = int.Parse(GetInput("How many contracts to this worker? "));
            for (int index = 0; index < NumberOfContracts; index++)
            {
                Console.WriteLine($"Enter #{index + 1} contract data:");
                worker.AddContract(CreateContract);
            }

            DateTime date = DateTime.Parse(GetInput("Enter month and year to calculate income (MM/YYYY): "));
            double income = worker.Income(date);
            Console.Write($"Name: {worker.Name}\nDepartment: {worker.Department.Name}\nIncome for {date.ToString("MM/yyyy")}: {income:F2}");
        }

        static HourContract CreateContract => new HourContract(
            DateTime.Parse(GetInput("Date (DD/MM/YYYY): ")),
            double.Parse(GetInput("Value per hour: "), CultureInfo.InvariantCulture),
            int.Parse(GetInput("Duration (hours): "))
        );
        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}