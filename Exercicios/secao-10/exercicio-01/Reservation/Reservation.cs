namespace Secao10.exercicio_01
{
    class Reservation
    {
        public int RoomNumber { get; private set; }
        public DateTime CheckIn { get; private set; } = DateTime.Parse("01/01/0001");
        public DateTime CheckOut { get; private set; } = DateTime.Parse("01/01/0001");

        public Reservation(string RoomNumber, (DateTime, DateTime) Dates)
        {
            this.RoomNumber = int.Parse(RoomNumber);
            UpdateDates(Dates);
        }
        public int Duration(DateTime checkIn, DateTime checkOut)
        {
            int duration = 0;
            duration = checkOut.DayOfYear - checkIn.DayOfYear;

            if (duration <= 0) throw new ReservationException("Check-out date must be after check-in date");

            return duration;
        }
        public void UpdateDates((DateTime, DateTime) Dates)
        {
            DateTime checkIn = Dates.Item1;
            DateTime checkOut = Dates.Item2;

            int duration = Duration(checkIn, checkOut);
            DateTime now = DateTime.Now;
            if (checkIn < CheckIn) throw new ReservationException("Reservation dates for update must be future dates");
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
        public override string ToString()
        {
            return $"Room {RoomNumber}, check-in: {CheckIn.ToString("dd/MM/yyyy")}, check-out: {CheckOut.ToString("dd/MM/yyyy")}, {Duration(CheckIn, CheckOut)} nights\n";
        }
    }
}