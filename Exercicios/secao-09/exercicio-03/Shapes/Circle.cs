namespace Secao9.exercicio_03
{
    class Circle : Shape
    {
        public double Radius { get; private set; }

        public Circle(double Radius, string Color) : base(Color) => this.Radius = Radius;
        public override double Area => Math.PI * Math.Pow(Radius, 2);
    }
}