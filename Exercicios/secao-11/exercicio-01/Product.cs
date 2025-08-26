using System.Globalization;

namespace Secao11.exercicio_01
{
    class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }

        public Product(string Name, string Price, string Quantity)
        {
            this.Name = Name;
            this.Price = double.Parse(Price, CultureInfo.InvariantCulture);
            this.Quantity = int.Parse(Quantity);
        }
        public double TotalPrice => Price * Quantity;
        public override string ToString()
        {
            return $"{Name},{TotalPrice.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}