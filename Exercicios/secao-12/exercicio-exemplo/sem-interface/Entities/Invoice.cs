namespace Secao12.exercicio_exemplo.sem_interface.Entities
{
    class Invoice
    {
        public double BasicPayment { get; private set; }
        public double Tax { get; private set; }

        public Invoice(double BasicPayment, double Tax)
        {
            this.BasicPayment = BasicPayment;
            this.Tax = Tax;
        }
        public double TotalPayment => Tax + BasicPayment;
        public override string ToString()
        {
            return $"Basic payment: {BasicPayment:F2}\nTax: {Tax:F2}\nTotal payment: {TotalPayment:F2}";
        }
    }
}