using System;
using System.Globalization;
using System.IO;

namespace Termo
{
    class Game
    {
        static readonly string PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        @"..\..\..\Exercicios\termo\palavras.txt");
        static void Main(string[] args)
        {
            Console.Write(PickRandomWord());
        }

        static string PickRandomWord()
        {
            string[] palavras = File.ReadAllLines(PATH);
            Random rnd = new Random();
            return palavras[rnd.Next(palavras.Length)];
        }
    }
}