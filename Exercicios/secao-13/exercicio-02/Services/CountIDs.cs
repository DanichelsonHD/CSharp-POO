using Secao13.Exercicio_02.Entities;

namespace Secao13.Exercicio_02.Services
{
    class CountIDs
    {
        public int Count(HashSet<Course> courses)
        {
            HashSet<Student> students = new HashSet<Student>();
            foreach (Course course in courses) students.UnionWith(course.Students);

            return students.Count;
        }
    }
}