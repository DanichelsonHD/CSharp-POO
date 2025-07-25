using System;

namespace Secao3
{
    class Ex2_4
    {
        static void Main4(string[] args)
        {
            Console.Write("Digite dois números inteiros: ");
            string[] numbers = Console.ReadLine().Split(' ');
            int number1 = int.Parse(numbers[0]);
            int number2 = int.Parse(numbers[1]);
            int totalTime = Calc_Total_Time(number1, number2);
        }

        static int Calc_Total_Time(int n1, int n2)
        {
            int totalTime = n2 - n1;
            if (totalTime <= 0) { totalTime += 24; }
            System.Console.WriteLine($"O JOGO DUROU {totalTime} HORA(S)");
            return totalTime;
        }
    }
}