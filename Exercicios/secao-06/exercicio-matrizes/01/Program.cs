using System;
using System.Globalization;

namespace Secao6
{
    class ExMatrizes_01
    {
        static void Main1(string[] args)
        {
            Console.Write("Digite o tamanho da matriz quadrada: ");
            int matrixLength = int.Parse(Console.ReadLine());
            int[,] squareMatrix = new int[matrixLength, matrixLength];
            int negativeCount = 0;

            Console.WriteLine($"Digite os valores da matriz {matrixLength}x{matrixLength}:");
            for (int index = 0; index < matrixLength; index++)
            {
                int[] row = GetValues(matrixLength);
                foreach (int value in row)
                {
                    if (value < 0) negativeCount++;
                    squareMatrix[index, Array.IndexOf(row, value)] = value;
                }
            }

            Console.WriteLine($"\nMain diagonal: ");
            string diagonal = string.Empty;
            for (int index = 0; index < matrixLength; index++) diagonal += squareMatrix[index, index] + " ";
            Console.WriteLine(diagonal);
            Console.WriteLine($"Negative numbers = {negativeCount}");
        }

        static int[] GetValues(int size)
        {
            int[] input = new int[size];
            return input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }
    }
}