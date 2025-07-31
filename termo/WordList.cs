using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Termo
{
    class WordList
    {
        private static string fileLocation = @"..\..\..\termo\src\";
        private static string pathWithAccent = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileLocation + "palavras_com_acento.txt");
        private static string pathWithoutAccent = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileLocation + "palavras_sem_acento.txt");

        public static string[] wordsWithAccent = File.ReadAllLines(pathWithAccent);
        public static string[] wordsWithoutAccent = File.ReadAllLines(pathWithoutAccent);

        public static HashSet<string> validWords = LoadValidWords();
        static HashSet<string> LoadValidWords()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileLocation + "palavras_validas.txt");
            if (!File.Exists(path))
            {
                Console.WriteLine("Arquivo de palavras válidas não encontrado.");
                Environment.Exit(1);
            }

            var lines = File.ReadAllLines(path);
            return new HashSet<string>(
                lines.Select(w => RemoveAccents(w.Trim().ToUpper(CultureInfo.InvariantCulture)))
            );
        }

        public static string RemoveAccents(string input)
        {
            input = input.Normalize(NormalizationForm.FormD);
            Regex regex = new Regex(@"[\u0300-\u036f]");
            return regex.Replace(input, "");
        }

        public static (string wordsWithAccent, string wordsWithoutAccent) PickRandomWord()
        {
            Random rnd = new Random();
            int index = rnd.Next(wordsWithAccent.Length);

            return (
                wordsWithAccent[index].ToUpper(CultureInfo.InvariantCulture),
                wordsWithoutAccent[index].ToUpper(CultureInfo.InvariantCulture)
            );
        }
    }
}