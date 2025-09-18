namespace Secao13.Exercicio_02.Entities
{
    class Teacher
    {
        public string Name { get; private set; }
        public HashSet<Course> Courses { get; set; } = new HashSet<Course>();

        public Teacher(string Name) => this.Name = Name;
        public void AddCourse(Course course) => Courses.Add(course);
    }
}