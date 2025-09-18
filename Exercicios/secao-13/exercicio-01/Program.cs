using Secao13.Exercicio_01.Entities;

namespace Secao13.Exercicio_01 
{
    class Program
    {
        static void Main1(string[] args)
        {
            //Console.Write("Enter file full path: ");
            //string path = Console.ReadLine();
            string path = @"..\..\..\Exercicios\secao-13\exercicio-01\in.text";

            HashSet<UserLog> logs = new HashSet<UserLog>();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(' ');
                        logs.Add(new UserLog(line[0], line[1]));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"Total users: {logs.Count}");
        }
    }
}