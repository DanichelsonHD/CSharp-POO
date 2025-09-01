using Secao12.exercicio_exemplo.com_interface.Entities;

namespace Secao12.exercicio_exemplo.com_interface.Services
{
    class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }
        public ITaxService _taxService;

        public RentalService(double PricePerHour, double PricePerDay, ITaxService _taxService)
        {
            this.PricePerHour = PricePerHour;
            this.PricePerDay = PricePerDay;
            this._taxService = _taxService;
        }
        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan Duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment;
            if (Duration.TotalHours <= 12.0) basicPayment = PricePerHour * Math.Ceiling(Duration.TotalHours);
            else basicPayment = PricePerDay * Math.Ceiling(Duration.TotalDays);

            double tax = _taxService.Tax(basicPayment);
            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}