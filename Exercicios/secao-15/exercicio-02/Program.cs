using Secao15.Exercicio_02.Entities;
using System.Globalization;
using System.Linq;

namespace Secao15.Exercicio_02
{
    class Program
    {
        static void Main2(string[] args)
        {
            string path = @"..\..\..\Exercicios\secao-15\exercicio-02\in.txt";
            List<Employee> employees = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    employees.Add(new Employee(line[0], line[1], line[2]));
                }
            }

            Console.Write($"Enter salary: ");
            double minSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine($"Email of people whose salary is more than {minSalary:F2}:");
            var minSalaryEmployees = employees.Where(e => e.Salary >= minSalary).Select(e => e.Email).Order().ToList();
            foreach (string email in minSalaryEmployees) Console.WriteLine(email);

            double sumSalaryM = employees.Where(e => e.Name[0] == 'M').Select(e => e.Salary).Sum();

            Console.WriteLine($"Sum of salary of people whose name starts with 'M': {sumSalaryM:F2}");
        }
    }
}