namespace Secao9.exercicio_04
{
    class Individual : TaxPayer
    {
        public double HealthExpenditures { get; private set; }

        public Individual(string Name, double AnualIncome, double HealthExpenditures)
            : base(Name, AnualIncome) => this.HealthExpenditures = HealthExpenditures;
        public override double Tax()
        {
            double tax = 0.0;
            double maxValueToTax15 = 20000.00;
            if (AnualIncome <= maxValueToTax15) tax += AnualIncome * 0.15;
            else tax += AnualIncome * 0.25;
            if (HealthExpenditures > 0.0) tax -= HealthExpenditures * 0.5;
            return tax;
        }
    }
}