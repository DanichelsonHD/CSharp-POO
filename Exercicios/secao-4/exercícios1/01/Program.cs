using System;
using System.Dynamic;

namespace Secao4
{
    class Ex1_1
    {
        static void Main1(string[] args)
        {
            System.Console.WriteLine(Compare_Ages(2));
        }

        static string Compare_Ages(int number)
        {
            Person[] persons = new Person[number];
            (int maxAge, int index) = (0, 0);

            for (int i = 0; i < number; i++)
            {
                persons[i] = Input_Person(i + 1);
                if (persons[i].Age > maxAge)
                {
                    maxAge = persons[i].Age;
                    index = i;
                }
            }

            return $"Pessoa mais velha: {persons[index].Name}";
        }

        static Person Input_Person(int index)
        {
            Console.WriteLine($"Digite o nome e idade da {index}ª pessoa: ");
            System.Console.Write("Nome: ");
            string name = Console.ReadLine();

            System.Console.Write("Idade: ");
            int age = int.Parse(Console.ReadLine());

            return new Person
            {
                Name = name,
                Age = age
            };
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age;
        public float Salary;
    }
}