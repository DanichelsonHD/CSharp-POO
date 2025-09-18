namespace Secao13.Exercicio_02.Entities
{
    class Student
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public Student(int ID) => this.ID = ID;
        public Student(int ID, string Name) : this(ID) => this.Name = Name;
        public override int GetHashCode() => ID.GetHashCode();
        public override bool Equals(object? obj)
        {
            if (!(obj is Student)) return false;
            Student other = obj as Student;
            return ID.Equals(other.ID);
        }
    }
}