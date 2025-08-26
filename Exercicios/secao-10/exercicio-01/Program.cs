namespace Secao10.exercicio_01
{
    class Program
    {
        static void Main1(string[] args)
        {
            try
            {
                Reservation reservation = new Reservation(GetInput("Room number: "), GetDates());
                Console.WriteLine($"Reservation: {reservation.ToString()}");

                Console.WriteLine($"Enter data to update the reservation:");
                reservation.UpdateDates(GetDates());
                Console.WriteLine($"Reservation: {reservation.ToString()}");
            }
            catch (ReservationException e) { Console.WriteLine($"Error in reservation: {e.Message}"); }
        }

        static (DateTime, DateTime) GetDates()
        {
            return (DateTime.Parse(GetInput("Check-in date (dd/MM/yyyy): ")), DateTime.Parse(GetInput("Check-out date (dd/MM/yyyy): ")));
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}