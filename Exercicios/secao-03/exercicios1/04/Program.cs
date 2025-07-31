using System;

namespace Secao3
{
    class Ex1_4
    {
        static void Main4 (string[] args)
        {
            initialize();
        }

        static void initialize()
        {
            System.Console.Write("Número do funcionário: ");
            int? number = int.Parse(Console.ReadLine());
            System.Console.Write($"Número de horas trabalhadas pelo funcionário {number}: ");
            int? hours = int.Parse(Console.ReadLine());
            System.Console.Write($"Pagamento por hora do funcionário {number}: ");
            float? payment = float.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
            System.Console.WriteLine($"NUMBER = {number}\nSALARY = U$ {Calc_Payment(hours, payment):F2}");
        }

        static float? Calc_Payment(int? h, float? p)
        {
            return (float?)h * p;
        }
    }
}