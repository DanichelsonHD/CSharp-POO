using System;
using System.Runtime.ConstrainedExecution;

namespace ProvaLogicaDeProgramacao
{
    class Ex2_2
    {
        static void Main2(string[] args)
        {
            Start();
        }
        
        static void Start()
        {
            System.Console.Write("Digite a, b e c, para calcular os valores de x: ");
            string? abc = Console.ReadLine();
            string[] abc_separated = abc.Split(' ');

            float a = float.Parse(abc_separated[0], System.Globalization.CultureInfo.InvariantCulture);
            float b = float.Parse(abc_separated[1], System.Globalization.CultureInfo.InvariantCulture);
            float c = float.Parse(abc_separated[2], System.Globalization.CultureInfo.InvariantCulture);

            (float x1, float x2) = Calc_Roots(a, b, c);
            if (x1 != x2)
            {
                System.Console.WriteLine($"Raízes: {x1:F5} e {x2:F5}");
            } else
            {
                System.Console.WriteLine($"Raiz: {x1:F5}");
            }
        }

        static float Calc_Delta(float a, float b, float c)
        {
            if (a == 0.0f)
            {
                ErrorEventArgs e = new ErrorEventArgs(new Exception("A = 0"));
            }
            float delta = (float)Math.Pow(b, 2) - (4 * a * c);

            if (delta < 0.0f)
            {
                ErrorEventArgs e = new ErrorEventArgs(new Exception("Delta negativo"));
            }

            return delta;
        }

        static (float, float) Calc_Roots(float a, float b, float c)
        {
            float delta = Calc_Delta(a, b, c);

            if (delta == 0.0f)
            {
                System.Console.WriteLine("Delta igual a 0, tem somente uma raiz real");
                float x = -b / (2 * a);
                return (x, x);
            }

            float x1 = (b * -1 + (float)Math.Sqrt(delta))/(2 * a);
            float x2 = (b * -1 - (float)Math.Sqrt(delta))/(2 * a);
        
            return (x1, x2);
        }
    }
}