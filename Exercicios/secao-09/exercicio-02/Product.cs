namespace Secao9.exercicio_02
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
        public virtual string PriceTag => $"{Name} - R${Price:F2}";
    }

    class ImportedProduct : Product
    {
        public double CustomsFee { get; private set; }

        public ImportedProduct(string Name, double Price, double CustomsFee)
            : base(Name, Price) => this.CustomsFee = CustomsFee;
        public double TotalPrice => Price + CustomsFee;
        public override string PriceTag => $"{Name} - R${TotalPrice:F2} (Customs Fee: R${CustomsFee:F2})";
    }

    class UsedProduct : Product
    {
        public DateTime ManufactureDate { get; private set; }

        public UsedProduct(string Name, double Price, string Date) : base(Name, Price)
        {
            this.ManufactureDate = DateTime.Parse(Date);
        }
        public override string PriceTag => $"{Name} (Used) - R${Price:F2} (Manufacture date: {ManufactureDate:dd/MM/yyyy})";
    }
}