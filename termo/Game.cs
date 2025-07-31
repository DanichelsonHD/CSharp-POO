using System;
using System.Globalization;

namespace Termo
{
    class Game
    {
        static string[] wordsWithAccent = WordList.wordsWithAccent;
        static string[] wordsWithoutAccent = WordList.wordsWithoutAccent;

        static void Main1(string[] args)
        {
            StartGame();
        }

        public static void StartGame()
        {
            (string choosenWordWithAccent, string choosenWord) = WordList.PickRandomWord();
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
                    Console.WriteLine($"\n\nVocê perdeu! A palavra era: {choosenWordWithAccent}");
                    break;
                }
            }
            PlayAgain();
        }

        static bool VerifyWin(string filteredLetters, string word)
        {
            if (filteredLetters != word) return false;

            Console.WriteLine($"\n\nParabéns, você acertou a palavra: {word}!");
            return true;
        }

        static void PlayAgain()
        {
            Console.Write("Quer jogar novamente? (S/N): ");
            string response = Console.ReadLine().ToUpper(CultureInfo.InvariantCulture);

            if (response == "S") StartGame();
            else Console.WriteLine("Obrigado por jogar!");
        }

        static string GetInput()
        {
            while (true)
            {
                Console.Write("\n\nDigite uma palavra: ");
                string word = Console.ReadLine().ToUpper(CultureInfo.InvariantCulture);
                word = WordList.RemoveAccents(word);

                if (word.Length == 5 && WordList.validWords.Contains(word)) return word;

                Console.Write("Inválido");
            }
        }

        static string CompareWords(string input, string word)
        {
            char[] chosenWord = word.ToCharArray();
            char[] letters = new char[word.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == chosenWord[i])
                {
                    ChangeColor(ConsoleColor.Green);
                    letters[i] = input[i];
                    chosenWord[i] = '_';
                }
                else if (chosenWord.Contains(input[i]))
                {
                    ChangeColor(ConsoleColor.Yellow);
                    letters[i] = char.ToLower(input[i]);

                    int idx = Array.IndexOf(chosenWord, input[i]);
                    if (idx != -1) chosenWord[idx] = '_';
                }
                else
                {
                    ChangeColor(ConsoleColor.Red);
                    letters[i] = '_';
                }
                Console.Write(input[i]);
            }
            Console.ResetColor();
            return new string(letters);
        }

        static void ChangeColor(ConsoleColor color) => Console.ForegroundColor = color;
    }
}