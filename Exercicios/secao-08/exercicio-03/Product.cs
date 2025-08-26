namespace Secao8.exercicio_03
{
    class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }

        public Product(string Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
        public void SetNewPrice(double Price) { if(Price > 0.0 && Price != this.Price) this.Price = Price; }
    }
}