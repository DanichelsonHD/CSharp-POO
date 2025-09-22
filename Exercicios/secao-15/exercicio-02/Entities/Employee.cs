using System.Globalization;

namespace Secao15.Exercicio_02.Entities
{
    class Employee
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public double Salary { get; private set; }

        public Employee(string Name, string Email)
        {
            this.Name = Name;
            this.Email = Email;
        }
        public Employee(string Name, string Email, double Salary) : this(Name, Email) => this.Salary = Salary;
        public Employee(string Name, string Email, string Salary) : this(Name, Email) => this.Salary = double.Parse(Salary, CultureInfo.InvariantCulture);
    }
}