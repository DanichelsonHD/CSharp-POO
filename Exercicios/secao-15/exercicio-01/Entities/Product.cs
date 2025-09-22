using System.Globalization;

namespace Secao15.Exercicio_01.Entities
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
        public Product(string Name, string Price)
        {
            this.Name = Name;
            this.Price = double.Parse(Price, CultureInfo.InvariantCulture);
        }
        public override string ToString() => $"{Name},{Price.ToString("F2", CultureInfo.InvariantCulture)}";
    }
}