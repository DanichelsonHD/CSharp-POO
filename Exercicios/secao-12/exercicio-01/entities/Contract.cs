namespace Secao12.exercicio_01.entities
{
    class Contract
    {
        public int Number { get; private set; }
        public DateTime Date { get; private set; }
        public double TotalValue { get; private set; }
        public List<Installment> Installments { get; private set; } = new List<Installment>();

        public Contract(int Number, DateTime Date, double TotalValue)
        {
            this.Number = Number;
            this.Date = Date;
            this.TotalValue = TotalValue;
        }

        public void AddInstallment(Installment installment) => Installments.Add(installment);
    }
}