using System;

namespace Secao3
{
    class Ex2_6
    {
        static void Main6(string[] args)
        {
            Console.Write("Digite um número: ");
            float number = float.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
            int[] interval = Check_Interval(number);
        }

        static int[] Check_Interval(float number)
        {
            switch (number)
            {
                case >= 0 and <= 25:
                    System.Console.WriteLine("Intervalo [0, 25]");
                    return [0, 25];
                case > 25 and <= 50:
                    System.Console.WriteLine("Intervalo [25, 50]");
                    return [25, 50];
                case > 50 and <= 75:
                    System.Console.WriteLine("Intervalo [50, 75]");
                    return [50, 75];
                case > 75 and <= 100:
                    System.Console.WriteLine("Intervalo [75, 100]");
                    return [75, 100];
                default:
                    System.Console.WriteLine("Fora do intervalo");
                    return [];
            }
        }
    }
}