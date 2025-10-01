using Secao17.board;
using Secao17.chess;

namespace Secao17.ChessGame
{
    class Screen
    {
        public static void PrintMatch(ChessMatch chessMatch)
        {
            PrintBoard(chessMatch.board);
            Console.WriteLine();
            PrintCapturedPieces(chessMatch);
            Console.WriteLine();
            Console.WriteLine($"Turn: {chessMatch.turn}");
            Console.WriteLine($"Waiting player: {chessMatch.currentPlayer}");
        }
        public static void PrintCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine($"Captured Pieces:\nWhite:");
            PrintSet(chessMatch.capturedPieces(Color.White));
            Console.WriteLine("Black:");
            InYellow(() => PrintSet(chessMatch.capturedPieces(Color.Black)));
        }
        public static void PrintSet(HashSet<Piece> set)
        {
            string str = "[";
            foreach (Piece piece in set) str += $"{piece} ";
            if (str.Length > 1) str = str.Substring(0, str.Length - 1);
            Console.WriteLine(str + "]");
        }
        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalColor = Console.BackgroundColor;
            ConsoleColor possiblePositionColor = ConsoleColor.DarkGray;

            Console.WriteLine("   ------------------------");
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
                Console.WriteLine("|");
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
            else InYellow(() => Console.Write(piece));

            Console.Write(" ");
        }

        public static ChessPosition ReadChessPosition()
        {
            return new ChessPosition(Console.ReadLine());
        }
        private static void InYellow(Action action)
        {
            ConsoleColor buffer = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            action();
            Console.ForegroundColor = buffer;
        }
    }
}