using System;

namespace ProvaLogicaDeProgramacao
{
    class Ex1_2
    {
        static void Main2(string[] args)
        {
            System.Console.Write("Digite o raio do círculo: ");
            string? radius_str = Console.ReadLine();
            float radius = float.Parse(radius_str, System.Globalization.CultureInfo.InvariantCulture);

            float area = Calc_Circle_Area(radius);
            Console.WriteLine($"Área do círculo: {area:F4}");
        }

        static float Calc_Circle_Area(float radius)
        {
            float PI = 3.14159f;
            float area = PI * radius * radius;

            return area;
        }
    }
}