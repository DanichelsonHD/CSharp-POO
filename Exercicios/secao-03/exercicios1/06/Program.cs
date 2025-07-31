using System;

namespace Secao3
{
    class Ex1_6
    {
        /*

        Fazer um programa que leia três valores com ponto flutuante de dupla precisão: A, B e C. Em seguida, calcule e 
        mostre:  
        a) a área do triângulo retângulo que tem A por base e C por altura.  
        b) a área do círculo de raio C. (pi = 3.14159)  
        c) a área do trapézio que tem A e B por bases e C por altura.  
        d) a área do quadrado que tem lado B.  
        e) a área do retângulo que tem lados A e B.
        
        */
        static void Main6(string[] args)
        {
            initialize();
        }

        static void initialize()
        {
            System.Console.Write("Digite os valores A, B e C: ");
            string[] abc = Console.ReadLine().Split(' ');

            float A = GetFloat(abc[0]);
            float B = GetFloat(abc[1]);
            float C = GetFloat(abc[2]);

            float triangle = Calc_Triangle_Area(A, C);
            float circle = Calc_Circle_Area(C);
            float trapeze = Calc_Trapezoid_Area(A, B, C);
            float square = Calc_Square_Area(B);
            float rectangle = Calc_Rectangle_Area(A, B);

            System.Console.Write($"TRIANGULO: {triangle:F3} \nCIRCULO: {circle:F3} \nTRAPEZIO: {trapeze:F3} \nQUADRADO: {square:F3} \nRETANGULO: {rectangle:F3}");
        }

        static float Calc_Triangle_Area(float A, float C)
        {
            return (A * C) / 2;
        }

        static float Calc_Circle_Area (float C)
        {
            float PI = 3.14159f;
            return PI * (float)Math.Pow(C, 2);
        }

        static float Calc_Trapezoid_Area(float A, float B, float C)
        {
            return (A + B) / 2 * C;
        }

        static float Calc_Square_Area (float B)
        {
            return (float)Math.Pow(B, 2);
        }

        static float Calc_Rectangle_Area(float A, float B)
        {
            return A * B;
        }

        static float GetFloat(string number)
        {
            return float.Parse(number, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}