using System;

namespace Secao3
{
    class Ex1_5
    {
        static void Main5 (string[] args)
        {
            initialize();
        }

        static void initialize()
        {
            System.Console.Write("Digite o código do produto, quantidade e valor unitário: ");
            string? product1 = Console.ReadLine();

            System.Console.Write("Digite o código de outro produto, quantidade e valor unitário: ");
            string? product2 = Console.ReadLine();

            float sum = Calc_Products_Sum(product1, product2);
            System.Console.WriteLine($"VALOR A PAGAR: R$ {sum:F2}");
        }

        static float Calc_Products_Sum(string? p1, string? p2)
        {
            float price1 = Calc_Price(p1);
            float price2 = Calc_Price(p2);

            return price1 + price2;
        }

        static float Calc_Price(string? product)
        {
            string[] separatedProduct = product.Split(' ');
            int quantity = int.Parse(separatedProduct[1]);
            float unitPrice = float.Parse(separatedProduct[2], System.Globalization.CultureInfo.InvariantCulture);
            float price = quantity * unitPrice;

            return price;
        }
    }
}