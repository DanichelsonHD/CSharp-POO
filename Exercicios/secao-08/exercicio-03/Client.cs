namespace Secao8.exercicio_03
{
    class Client
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        public Client(string Name, string Email, string BirthDate)
        {
            this.Name = Name;
            this.Email = Email;
            this.BirthDate = DateTime.Parse(BirthDate);
        }
        public override string ToString()
        {
            return $"{Name} ({BirthDate:dd/MM/yyyy}) - {Email}";
        }
    }
}