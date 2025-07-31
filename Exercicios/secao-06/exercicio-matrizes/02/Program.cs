namespace Secao6
{
    class ExMatrizes_02
    {
        static void Main2(string[] args)
        {
            Console.Write($"Digite o tamanho da matriz (M x N): ");
            string[] MxN = Console.ReadLine().Split(' ');
            int m = int.Parse(MxN[0]);
            int n = int.Parse(MxN[1]);

            Console.WriteLine($"Digite os valores da matriz {m}x{n}:");
            int[,] matrix = CreateMatrix(m, n);

            Console.Write("Digite um valor da matriz para ser X: ");
            int x = int.Parse(Console.ReadLine());
            List<int[]> positions = FindValuePositions(matrix, x);

            PrintNeighbours(matrix, positions);
        }

        static void PrintNeighbours(int[,] matrix, List<int[]> positions)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            foreach (int[] cordinates in positions)
            {
                int x = cordinates[0];
                int y = cordinates[1];
                Console.WriteLine($"Position: {x}, {y}");

                if (y - 1 >= 0) Console.WriteLine($"Left: {matrix[x, y - 1]}");
                if (x - 1 >= 0) Console.WriteLine($"Up: {matrix[x - 1, y]}");                
                if (y + 1 < n) Console.WriteLine($"Right: {matrix[x, y + 1]}");
                if (x + 1 < m) Console.WriteLine($"Down: {matrix[x + 1, y]}");
            }
        }

        static List<int[]> FindValuePositions(int[,] matrix, int value)
        {
            List<int[]> positions = new List<int[]>();
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] == value)
                        positions.Add(new int[] { i, j });
            return positions;
        }

        static int[,] CreateMatrix(int m, int n)
        {
            int[,] matrix = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                int[] row = GetValues(n);
                foreach (int value in row) matrix[i, Array.IndexOf(row, value)] = value;
            }
            return matrix;
        }

        static int[] GetValues(int size)
        {
            int[] input = new int[size];
            return input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }
    }
}