using Secao17.board;
using Secao17.chess;

namespace Secao17.ChessGame
{
    class Screen
    {
        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalColor = Console.BackgroundColor;
            ConsoleColor possiblePositionColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.lines; i++)
            {
                Console.Write($"{8 - i} |");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possiblePositions[i, j]) Console.BackgroundColor = possiblePositionColor;
                    else Console.BackgroundColor = originalColor;
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("   ------------------------");
            Console.WriteLine("    a  b  c  d  e  f  g  h ");
        }
        public static void PrintBoard(Board board) => PrintBoard(board, new bool[board.lines, board.columns]);

        public static void PrintPiece(Piece piece)
        {
            Console.Write(" ");
            if (piece == null) Console.Write("-");
            else if (piece.color == Color.White) Console.Write(piece);
            else
            {
                ConsoleColor buffer = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = buffer;
            }
            Console.Write(" ");
        }

        public static ChessPosition ReadChessPosition()
        {
            return new ChessPosition(Console.ReadLine());
        }
    }
}