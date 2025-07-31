using System;

namespace Secao3
{
    class Ex4_3
    {
        static void Main3(string[] args)
        {
            System.Console.Write("Digite um número (ele será a quantia de casos requisitados): ");
            int count = int.Parse(Console.ReadLine());
            Get_Medians(count);
        }

        static float[] Get_Medians(int count)
        {
            float[] medians = new float[count];

            for (int i = 0; i < count; i++)
            {
                float[] numbers = Get_Numbers();
                int[] weights = { 2, 3, 5 };
                medians[i] = Get_Pondered_Median(numbers, weights);
                Console.WriteLine($"{medians[i]:F1}");
            }

            return medians;
        }

        static float[] Get_Numbers()
        {
            Console.Write("Digite três números decimais para calcular a média: ");
            string[] input = Console.ReadLine().Split(' ');
            float[] numbers = new float[input.Length];

            foreach (string number in input)
                numbers[Array.IndexOf(input, number)] = float.Parse(number, System.Globalization.CultureInfo.InvariantCulture);
            return numbers;
        }

        static float Get_Pondered_Median(float[] numbers, int[] weights)
        {
            float median = 0.0f;
            int totalWeight = 0;

            foreach (float number in numbers)
            {
                int tempWeight = weights[Array.IndexOf(numbers, number)];
                totalWeight += tempWeight;
                median += number * tempWeight;
            }

            return median / totalWeight;
        }
    }
}