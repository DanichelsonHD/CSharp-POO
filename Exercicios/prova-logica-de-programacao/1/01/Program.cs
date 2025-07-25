using System;

namespace ProvaLogicaDeProgramacao
{
    class Ex1_1
    {
        static void Main1(string[] args)
        {
            System.Console.Write("Digite o código do produto, quantidade e valor unitário: ");
            string? product1 = Console.ReadLine();
            System.Console.Write("Mais um produto: ");
            string? product2 = Console.ReadLine();

            float sum = Calc_Products_Sum(product1, product2);
            Console.WriteLine($"Valor total: R$ {sum:F2}");
        }

        static float Calc_Products_Sum (string product1, string product2)
        {
            string[] p1 = product1.Split(' ');
            string[] p2 = product2.Split(' ');

            if (p1.Length != 3 || p2.Length != 3)
            {
                System.Console.WriteLine("Síntaxe Inválida");
            }
            
            float sum = 0.0f;
            sum += int.Parse(p1[1]) * float.Parse(p1[2], System.Globalization.CultureInfo.InvariantCulture);
            sum += int.Parse(p2[1]) * float.Parse(p2[2], System.Globalization.CultureInfo.InvariantCulture);
            
            return sum;
        }
    }
}