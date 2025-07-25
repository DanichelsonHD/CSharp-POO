using System;

namespace Secao3
{
    class Ex4_4
    {
        static void Main4(string[] args)
        {
            Console.Write("Digite um número (será o número de divisões): ");
            int count = int.Parse(Console.ReadLine());
            Get_Divisions(count);
        }

        static void Get_Divisions(int count)
        {
            for (int i = 0; i < count; i++)
            {
                (int number1, int number2) = Get_Numbers();
                if (number2 == 0)
                {
                    System.Console.WriteLine("Divisão impossível");
                    continue;
                }

                float result = (float)number1 / number2;
                System.Console.WriteLine($"{result:F1}");
            }
        }

        static (int, int) Get_Numbers()
        {
            Console.Write("Digite dois números para dividir: ");
            string[] numbers = Console.ReadLine().Split(' ');
            return (int.Parse(numbers[0]), int.Parse(numbers[1]));
        }
    }
}