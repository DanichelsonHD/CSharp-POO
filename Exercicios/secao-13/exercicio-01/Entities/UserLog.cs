using System.Globalization;

namespace Secao13.Exercicio_01.Entities
{
    class UserLog
    {
        public string Name { get; private set; }
        public DateTime Time { get; private set; }
        public UserLog(string Name, string Time)
        {
            this.Name = Name;
            this.Time = DateTime.ParseExact(Time, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is UserLog)) return false;
            UserLog other = obj as UserLog;
            return Name.Equals(other.Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}