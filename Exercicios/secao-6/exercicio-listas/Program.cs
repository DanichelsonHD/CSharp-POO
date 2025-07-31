using System;
using System.Globalization;

namespace Secao6
{
    class ExListas
    {
        static void Main1(string[] args)
        {
            int number = int.Parse(GetInput("Quantia de funcionários a serem registrados: "));
            Employee[] employees = new Employee[number];

            for (int index = 0; index < number; index++)
            {
                Console.WriteLine($"\nEmployee #{index + 1}");
                employees[index] = RegisterEmployee();
            }

            IncreaseSalary(employees);

            Console.Write($"\nLista de funcionários:\n");
            foreach (Employee employee in employees) Console.WriteLine(employee.ToString());
        }

        static Employee RegisterEmployee() => new Employee
        {
            ID = GetInput("Id: "),
            Name = GetInput("Nome: "),
            Salary = double.Parse(GetInput("Salário: "), CultureInfo.InvariantCulture)
        };

        static void IncreaseSalary(Employee[] employees)
        {
            string id = GetInput("\nId do funcionário que irá receber um aumento: ");
            double percentage = double.Parse(GetInput("Porcentagem do aumento: "), CultureInfo.InvariantCulture);
            Employee employee = Array.Find(employees, x => x.ID == id);
            employee.IncreaseSalary(percentage);
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }

    class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public void IncreaseSalary(double percentage) => Salary *= 1 + percentage / 100.0;
        public override string ToString() => $"{ID}, {Name}, {Salary:F2}";
    }
}