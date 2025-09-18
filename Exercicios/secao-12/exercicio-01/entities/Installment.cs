namespace Secao12.exercicio_01.entities
{
    class Installment
    {
        public DateTime DueDate { get; private set; }
        public double Amount { get; private set; }

        public Installment(DateTime DueDate, double Amount)
        {
            this.DueDate = DueDate;
            this.Amount = Amount;
        }
        public override string ToString()
        {
            return $"{DueDate:dd/MM/yyyy} - {Amount:F2}";
        }
    }
}