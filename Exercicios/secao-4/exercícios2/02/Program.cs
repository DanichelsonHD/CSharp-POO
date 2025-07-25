using System;

namespace Secao4
{
    class Ex2_2
    {
        static void Main2(string[] args)
        {
            Employee employee = Create_Employee();
            System.Console.WriteLine($"Funcionário: {employee.Name}, R$ {employee.LiquidSalary:F2}");
            Console.Write("Digite a porcentagem para aumentar o salário: ");
            employee.IncreaseSalary(Input_Float);
            System.Console.WriteLine($"Dados atualizados: {employee.Name}, R$ {employee.LiquidSalary:F2}");
        }

        static Employee Create_Employee()
        {
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            System.Console.Write("Salário: ");
            float salary = Input_Float;
            System.Console.Write("Imposto: ");
            float tax = Input_Float;

            return new Employee
            {
                Name = name,
                BruteSalary = salary,
                Tax = tax
            };
        }

        static float Input_Float => float.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
    }

    class Employee
    {
        public string Name { get; set; }
        public float BruteSalary { get; set; }
        public float Tax { get; set; }
        public float LiquidSalary => BruteSalary - Tax;
        public void IncreaseSalary(float percentage) => BruteSalary += BruteSalary * percentage / 100;
    }
}