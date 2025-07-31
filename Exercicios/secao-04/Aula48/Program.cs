using System;
using System.Globalization;

namespace Secao4
{
    class Ex48
    {
        static void Main48(string[] args)
        {
            ConversorDeMoeda conversor = new ConversorDeMoeda();
            Console.Write("Cotação do Dólar: ");
            conversor.DollarPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Total de Dólares a converter: ");
            conversor.Quantity = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            System.Console.WriteLine($"Valor convertido em Reais: {conversor.Convert_To_Real:F2}");
        }
    }

    class ConversorDeMoeda
    {
        public double DollarPrice { get; set; }
        public double Quantity { get; set; }
        public static double IOF = 0.06;
        public double Convert_To_Real => DollarPrice * Quantity * (1 + IOF);
    }
}