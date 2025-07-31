using System;

namespace Secao4
{
    class Ex2_1
    {
        static void Main1(string[] args)
        {
            System.Console.WriteLine("Entre a largura e altura do retângulo: ");
            Rectangle rectangle = new Rectangle()
            {
                Width = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture),
                Height = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture)
            };
            System.Console.WriteLine($"Área = {rectangle.Area:F2}");
            System.Console.WriteLine($"Perímetro = {rectangle.Perimeter:F2}");
            System.Console.WriteLine($"Diagonal = {rectangle.Diagonal:F2}");
        }
    }

    class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public double Area => Width * Height;
        public double Perimeter => (Width + Height) * 2;
        public double Diagonal => Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
    }
}