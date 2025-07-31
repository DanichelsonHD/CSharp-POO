using System;

namespace Secao4
{
    class Ex2_3
    {
        static void Main3(string[] args)
        {
            Console.Write("Nome do aluno: ");
            string name = Console.ReadLine();
            Console.WriteLine("Digite as três notas do aluno: ");
            Student student = new Student()
            {
                Name = name,
                Grade1 = Input_Float,
                Grade2 = Input_Float,
                Grade3 = Input_Float
            };

            System.Console.WriteLine($"Nota final: {student.FinalGrade:F2}");
            System.Console.WriteLine(student.Status);
            if (student.Status == "Reprovado")
            {
                System.Console.WriteLine($"Faltaram {student.MissingPoints:F2} pontos");
            }
        }

        static float Input_Float => float.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
    }

    class Student
    {
        public string Name { get; set; }
        public float Grade1 { get; set; }
        public float Grade2 { get; set; }
        public float Grade3 { get; set; }
        public float FinalGrade => Grade1 + Grade2 + Grade3;
        public string Status => FinalGrade >= 60.0f ? "Aprovado" : "Reprovado";
        public float MissingPoints => Status == "Reprovado" ? 60.0f - FinalGrade : 0.0f;
    }
}