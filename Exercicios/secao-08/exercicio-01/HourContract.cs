namespace Secao8.exercicio_01
{
    public class HourContract
    {
        public DateTime Date { get; private set; }
        public double ValuePerHour { get; private set; }
        public int Hours { get; private set; }

        public HourContract(DateTime Date, double ValuePerHour, int Hours)
        {
            this.Date = Date;
            this.ValuePerHour = ValuePerHour;
            this.Hours = Hours;
        }
        public double TotalValue => ValuePerHour * Hours;
    }
}