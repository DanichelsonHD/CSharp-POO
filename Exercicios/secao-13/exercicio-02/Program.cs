using Secao13.Exercicio_02.Entities;
using Secao13.Exercicio_02.Services;

namespace Secao13.Exercicio_02
{
    class Program
    {
        static void Main2(string[] args)
        {
            Teacher teacher = new Teacher("Alex");
            teacher.AddCourse(newCourse("A"));
            teacher.AddCourse(newCourse("B"));
            teacher.AddCourse(newCourse("C"));

            int totalStudents = new CountIDs().Count(teacher.Courses);
            Console.WriteLine($"Total Students: {totalStudents}");
        }

        static Course newCourse(string Name)
        {
            Course course = new Course(Name);
            int quantity = int.Parse(GetInput($"How many students for course {Name}? "));
            for (int index = 0; index < quantity; index++)
            {
                int id = int.Parse(Console.ReadLine());
                Student student = new Student(id);
                course.AddStudent(student);
            }
            return course;
        }
        
        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}