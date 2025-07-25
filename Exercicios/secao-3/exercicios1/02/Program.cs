using System;

namespace Secao3
{
    class Ex1_2
    {
        static float PI = 3.14159f;
        static void Main2 (string[] args)
        {
            initialize();
        }

        static void initialize ()
        {
            System.Console.Write("Digite um valor para o raio do círculo: ");
            float radius = float.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
            
            System.Console.WriteLine($"A={Calc_Circle_Area(radius):F4}"); 
        }

        static float Calc_Circle_Area (float radius)
        {
            return PI * (float)Math.Pow(radius, 2);
        }
    }
}