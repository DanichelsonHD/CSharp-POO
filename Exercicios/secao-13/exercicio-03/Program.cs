using System;
using System.Globalization;

namespace Secao13.Exercicio_03
{
    class Program
    {
        static void Main3(string[] args)
        {
            string path = @"..\..\..\Exercicios\secao-13\exercicio-03\in.txt";
            Dictionary<string, int> votes = new Dictionary<string, int>();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        if (votes.ContainsKey(line[0]))
                            votes[line[0]] += int.Parse(line[1]);
                        else
                            votes[line[0]] = int.Parse(line[1]);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            
            foreach (var vote in votes) Console.WriteLine($"{vote.Key}: {vote.Value}");
        }
    }
}