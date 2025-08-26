namespace Secao9.exercicio_04
{
    class Company : TaxPayer
    {
        public int NumberOfEmployees { get; private set; }

        public Company(string Name, double AnualIncome, int NumberOfEmployees)
            : base(Name, AnualIncome) => this.NumberOfEmployees = NumberOfEmployees;
        public override double Tax()
        {
            int minPeopleTax14 = 10;
            if (NumberOfEmployees > minPeopleTax14) return AnualIncome * 0.14;
            else return AnualIncome * 0.16;
        }
    }
}