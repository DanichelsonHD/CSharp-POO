using Secao17.board;
using Secao17.chess;
using tabuleiro;

namespace Secao17.ChessGame
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write($"{8 - i} | ");
                for (int j = 0; j < board.columns; j++) PrintPiece(board.Piece(i, j));
                Console.WriteLine();
            }
            Console.WriteLine("   ----------------");
            Console.WriteLine("    a b c d e f g h");

        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null) Console.Write($"- ");
            else if (piece.color == Color.White) Console.Write($"{piece} ");
            else
            {
                ConsoleColor buffer = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = buffer;
                Console.Write(" ");
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            return new ChessPosition(Console.ReadLine());
        }
    }
}