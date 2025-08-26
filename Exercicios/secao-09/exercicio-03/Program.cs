using System.Globalization;

namespace Secao9.exercicio_03
{
    class Program
    {
        static void Main3(string[] args)
        {
            int n = int.Parse(GetInput("Enter the number of shapes: "));
            List<Shape> shapes = new List<Shape>();
            while (shapes.Count() < n)
            {
                Console.WriteLine($"Shape #{shapes.Count() + 1} data:");
                shapes.Add(NewShape());
                Console.WriteLine();
            }

            Console.WriteLine("SHAPE AREAS:");
            foreach (Shape shape in shapes) Console.WriteLine(shape.Area.ToString("F2", CultureInfo.InvariantCulture));
        }

        static Shape NewShape()
        {
            string ShapeType = GetInput("Rectangle or Circle (r/c)? ").ToLower();
            string color = GetInput("Color (Black/Blue/Red/Green): ");
            if (ShapeType == "r")
            {
                double width = ToDouble("Width: ");
                double height = ToDouble("Height: ");
                return new Rectangle(width, height, color);
            }
            else if (ShapeType == "c")
            {
                double radius = ToDouble("Radius: ");
                return new Circle(radius, color);
            }
            return new Circle(0.0, color);
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static double ToDouble(string prompt) => double.Parse(GetInput(prompt), System.Globalization.CultureInfo.InvariantCulture);
    }
}