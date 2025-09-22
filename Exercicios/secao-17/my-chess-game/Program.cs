using Secao17.board;
using Secao17.chess;

namespace Secao17.ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            board.PutPiece(new Rook(board, Color.Black), new Position(0, 0));
            board.PutPiece(new Rook(board, Color.Black), new Position(1, 3));
            board.PutPiece(new King(board, Color.Black), new Position(2, 4));

            Screen.PrintBoard(board);

            Console.WriteLine();
        }
    }
}