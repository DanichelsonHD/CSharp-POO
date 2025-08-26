namespace Secao9.exercicio_03
{
    abstract class Shape
    {
        public Color Color { get; set; }

        public Shape(string Color) => this.Color = ToColor(Color);
        public virtual double Area => 0.0;
        public Color ToColor(string color)
        {
            color = color.ToLower();
            switch (color)
            {
                case "black":
                    return Color.BLACK;
                case "blue":
                    return Color.BLUE;
                case "red":
                    return Color.RED;
                case "green":
                    return Color.GREEN;
                default:
                    return Color.BLACK;
            }
        }
    }
}