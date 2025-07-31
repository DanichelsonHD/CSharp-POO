using System;
using System.Runtime.InteropServices.Swift;

namespace Secao3
{
    class Ex4_2
    {
        static void Main2(string[] args)
        {
            System.Console.Write("Digite um número (ele será a quantia de números requisitados): ");
            int number = Get_Input();
            Get_Numbers_In_Between(number);
        }

        static object Get_Numbers_In_Between(int number)
        {
            Interval interval = new Interval();

            for (int i = 0; i < number; i++)
            {
                int input = Get_Input();
                if (input >= 10 && input <= 20) interval.In++;
                else interval.Out++;
            }

            Console.WriteLine($"{interval.In} in");
            Console.WriteLine($"{interval.Out} out");

            return interval;
        }

        static int Get_Input()
        {
            return int.Parse(Console.ReadLine());
        }
    }

    class Interval
    {
        public int In = 0;
        public int Out = 0;
    }
}