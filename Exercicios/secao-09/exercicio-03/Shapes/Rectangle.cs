namespace Secao9.exercicio_03
{
    class Rectangle : Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectangle(double Width, double Height, string Color) : base(Color)
        {
            this.Width = Width;
            this.Height = Height;
        }
        public override double Area => Width * Height;
    }
}