using System.Globalization;
using Secao12.exercicio_exemplo.sem_interface.Entities;
using Secao12.exercicio_exemplo.sem_interface.Services;

namespace Secao12.exercicio_exemplo.sem_interface
{
    class Program
    {
        static void Main1(string[] args)
        {
            Vehicle vehicle = new Vehicle(GetInput("Enter rental data\nCar model: "));
            DateTime start = ConvertToDateTime(GetInput("Pickup (dd/MM/yyyy hh:mm): "));
            DateTime finish = ConvertToDateTime(GetInput("Return (dd/MM/yyyy hh:mm): "));
            CarRental carRental = new CarRental(start, finish, vehicle);

            double pricePerHour = double.Parse(GetInput("Enter price per hour: "), CultureInfo.InvariantCulture);
            double pricePerDay = double.Parse(GetInput("Enter price per day: "), CultureInfo.InvariantCulture);
            RentalService rentalService = new RentalService(pricePerHour, pricePerDay);

            rentalService.ProcessInvoice(carRental);
            Console.Write("Invoice:\n" + carRental.Invoice);
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static DateTime ConvertToDateTime(string input)
        {
            return DateTime.ParseExact(input, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        }
    }
}