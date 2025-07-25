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
}