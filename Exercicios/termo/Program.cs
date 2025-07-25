using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Termo
{
    class Game
    {
        static readonly string PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        @"..\..\..\Exercicios\termo\palavras.txt");
        

        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            string choosenWord = PickRandomWord();
            int tries = 1;
            int chances = 6;
            bool won = false;
            Console.Write($"Bem-vindo ao TERMO! \n\nVocê tem {chances} tentativas para acertar a palavra escolhida com 5 letras.\n\n" +
            "Verde significa letra correta e posição correta, \nAmarelo significa letra correta, mas posição errada, \n" +
            "Vermelho significar letra incorreta.\n\nBoa sorte!\n");
            while (!won)
            {
                string coloredLetters = CompareWords(GetInput(), choosenWord);
                if (chances > tries)
                {
                    Console.WriteLine($"\n{chances - tries} tentativas restantes.\n");
                    won = VerifyWin(coloredLetters, choosenWord);
                    tries++;
                }
                else
                {
                    Console.WriteLine($"\n\nVocê perdeu! A palavra era: {choosenWord}");
                    break;
                }
            }
            Console.Write("Quer jogar novamente? (S/N): ");
            string response = Console.ReadLine().ToUpper(CultureInfo.InvariantCulture);
            if (response == "S") StartGame();
            else Console.WriteLine("Obrigado por jogar!");
        }

        static string PickRandomWord()
        {
            string[] palavras = File.ReadAllLines(PATH);
            Random rnd = new Random();
            return palavras[rnd.Next(palavras.Length)].ToUpper(CultureInfo.InvariantCulture);
        }

        static string GetInput()
        {
            Console.Write("\n\nDigite uma palavra: ");
            string word = Console.ReadLine().ToUpper(CultureInfo.InvariantCulture);
            word = RemoveAccents(word);

            if (word.Length == 5) return word;
            Console.Write("Inválido");
            return GetInput();
        }

        static string RemoveAccents(string input)
        {
            input = input.Normalize(NormalizationForm.FormD);
            Regex regex = new Regex(@"[\u0300-\u036f]");
            return regex.Replace(input, "");
        }

        static string CompareWords(string input, string word)
        {
            char[] letters = new char[word.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == word[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    letters[i] = input[i];
                }
                else if (word.Contains(input[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    letters[i] = char.ToLower(input[i]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    letters[i] = ' ';
                }
                Console.Write(input[i]);
            }
            Console.ResetColor();
            return new string(letters);
        }

        static bool VerifyWin(string filteredLetters, string word)
        {
            if (filteredLetters == word)
            {
                Console.WriteLine($"\n\nParabéns, você acertou a palavra: {word}!");
                return true;
            }
            return false;
        }
    }
}