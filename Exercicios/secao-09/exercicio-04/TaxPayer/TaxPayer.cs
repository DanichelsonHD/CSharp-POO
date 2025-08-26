namespace Secao9.exercicio_04
{
    abstract class TaxPayer
    {
        public string Name { get; private set; }
        public double AnualIncome { get; private set; }

        public TaxPayer(string Name, double AnualIncome)
        {
            this.Name = Name;
            this.AnualIncome = AnualIncome;
        }
        public virtual double Tax() => 0.0;
        public override string ToString()
        {
            return $"{Name}: R${Tax():F2}";
        }
    }
}