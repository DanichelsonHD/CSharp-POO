using System;

namespace Secao3
{
    class Ex2_7
    {
        static void Main7(string[] args)
        {
            int quadrant = 1;
            while (quadrant != 0 && quadrant != -1)
            {
                Console.Write("Digite algo: ");
                string[] axis = Console.ReadLine().Split(' ');
                float x = float.Parse(axis[0], System.Globalization.CultureInfo.InvariantCulture);
                float y = float.Parse(axis[1], System.Globalization.CultureInfo.InvariantCulture);
                quadrant = Verify_Quadrant(x, y);
            }
        }

        static int Verify_Quadrant(float x, float y)
        {
            switch (x, y)
            {
                case (0, 0):
                    Console.WriteLine("Origem");
                    return 0;
                case ( > 0, > 0):
                    Console.WriteLine("Q1");
                    return 1;
                case ( < 0, > 0):
                    Console.WriteLine("Q2");
                    return 2;
                case ( < 0, < 0):
                    Console.WriteLine("Q3");
                    return 3;
                case ( > 0, < 0):
                    Console.WriteLine("Q4");
                    return 4;
                case (0, not 0):
                    Console.WriteLine("Eixo Y");
                    return 0;
                case (not 0, 0):
                    Console.WriteLine("Eixo X");
                    return 0;
                default:
                    Console.WriteLine("Ponto inválido");
                    return -1;
            }
        }
    }
}