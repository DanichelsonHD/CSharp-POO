using System;
using System.Runtime.ConstrainedExecution;

namespace ProvaLogicaDeProgramacao
{
    class Ex2_1
    {
        static (string, float)[] food = new (string, float)[]
        {
            ("", 0.0f),
            ("Cachorro Quente", 4.0f),
            ("X-Salada", 4.50f),
            ("X-Bacon", 5.0f),
            ("Torrada Simples", 2.0f),
            ("Refrigerante", 1.50f)
        
        };
        static void Main_(string[] args)
        {
            Print_Food_Menu();
            System.Console.WriteLine("Digite o código do produto e a quantidade: ");
            string? product = Console.ReadLine();
            
            float price = Calc_Food_Price(product);
            System.Console.WriteLine($"Valor total: R$ {price:F2}");
        }

        static void Print_Food_Menu()
        {
            System.Console.WriteLine($"{"Código", -6}\t{"Produto", -20}\t\t{"Preço", 6}");
            for(int i = 1; i < food.Length; i++)
            {
                System.Console.WriteLine($"{i, -6}\t{food[i].Item1, -20}\t\tR$ {food[i].Item2, 6:F2}");
            }
        }

        static float Calc_Food_Price (string product)
        {
            string[] product_separated= product.Split(' ');
            if(product_separated.Length != 2)
            {
                System.Console.WriteLine("Síntaxe Inválida");
                return 0.0f;
            }

            int code = int.Parse(product_separated[0]);
            int quantity = int.Parse(product_separated[1]);

            if (code < 1 || code > food.Length)
            {
                System.Console.WriteLine("Não está no cardápio");
                return 0.0f;
            }

            return food[code].Item2 * quantity;
        }
    }

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