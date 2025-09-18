namespace Secao13.Exercicio_02.Entities
{
    class Course
    {
        public string Name { get; private set; }
        public HashSet<Student> Students { get; private set; } = new HashSet<Student>();

        public Course(string Name) => this.Name = Name;
        public void AddStudent(Student student) => Students.Add(student);
    }
}