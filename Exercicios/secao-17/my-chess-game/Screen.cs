using Secao17.board;

namespace Secao17.ChessGame
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    Piece piece = board.Piece(i, j);
                    if (piece == null) Console.Write($"- ");
                    else Console.Write($"{piece} ");
                }
                Console.WriteLine();
            }

        }
    }
}