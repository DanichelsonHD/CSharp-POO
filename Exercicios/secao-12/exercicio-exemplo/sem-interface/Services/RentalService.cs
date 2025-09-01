using Secao12.exercicio_exemplo.sem_interface.Entities;

namespace Secao12.exercicio_exemplo.sem_interface.Services
{
    class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }
        public BrazilTaxService _brazilTaxService = new BrazilTaxService();

        public RentalService(double PricePerHour, double PricePerDay)
        {
            this.PricePerHour = PricePerHour;
            this.PricePerDay = PricePerDay;
        }
        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan Duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment;
            if (Duration.TotalHours <= 12.0) basicPayment = PricePerHour * Math.Ceiling(Duration.TotalHours);
            else basicPayment = PricePerDay * Math.Ceiling(Duration.TotalDays);

            double tax = _brazilTaxService.Tax(basicPayment);
            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}