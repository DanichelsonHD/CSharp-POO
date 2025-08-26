using System.Globalization;

namespace Secao9.exercicio_01
{
    class Program
    {
        static void Main1(string[] args)
        {
            int n = int.Parse(GetInput("Enter the number of employees: "));
            List<Employee> employees = new List<Employee>();
            while (employees.Count() < n)
            {
                Console.WriteLine($"Employee #{employees.Count() + 1} data:");
                employees.Add(NewEmployee());
                Console.WriteLine();
            }

            Console.WriteLine("PAYMENTS:");
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.Name} - R${employee.Payment:F2}");
            }
        }

        static Employee NewEmployee()
        {
            bool IsOutsourced = (GetInput("Outsourced (y/n)? ").ToLower() == "y") ? true : false;

            string name = GetInput("Name: ");
            int hours = int.Parse(GetInput("Hours: "));
            double valuePerHour = double.Parse(GetInput("Value per hour: "), CultureInfo.InvariantCulture);

            if (!IsOutsourced) return new Employee(name, hours, valuePerHour);
            
            double additionalCharge = double.Parse(GetInput("Additional charge: "), CultureInfo.InvariantCulture);
            return new OutsourcedEmployee(name, hours, valuePerHour, additionalCharge);
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}