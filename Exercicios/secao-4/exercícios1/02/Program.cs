using System;

namespace Secao4
{
    class Ex1_2
    {
        static void Main2(string[] args)
        {
            float average = Calc_Average_Salary(2);
            System.Console.WriteLine($"Salário médio = {average:F2}");
        }

        static float Calc_Average_Salary(int number)
        {
            Person[] persons = new Person[number];
            float totalSalary = 0.0f;

            for (int i = 0; i < number; i++)
            {
                persons[i] = Input_Person(i + 1);
                totalSalary += persons[i].Salary;
            }

            return totalSalary / number;
        }

        static Person Input_Person(int index)
        {
            Console.WriteLine($"Dados do {index}º funcionário: ");
            System.Console.Write("Nome: ");
            string name = Console.ReadLine();

            System.Console.Write("Salário: ");
            float salary = float.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);

            return new Person
            {
                Name = name,
                Salary = salary
            };
        }
    }
}