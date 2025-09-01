namespace Secao12.exercicio_exemplo.sem_interface.Entities
{
    class CarRental
    {
        public DateTime Start { get; private set; }
        public DateTime Finish { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public Invoice Invoice { get; set; }

        public CarRental(DateTime Start, DateTime Finish, Vehicle Vehicle)
        {
            this.Start = Start;
            this.Finish = Finish;
            this.Vehicle = Vehicle;
        }
    }
}