using Secao17.board;
using Secao17.chess;

namespace Secao17.ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessMatch chessMatch = new ChessMatch();

            while (!chessMatch.ended)
            {
                Console.Clear();
                Screen.PrintBoard(chessMatch.board);

                Console.Write($"\nOrigin: ");
                Position origin = Screen.ReadChessPosition().ToPosition();

                bool[,] possibleMoves = chessMatch.board.Piece(origin).ValidMoves();

                Console.Clear();
                Screen.PrintBoard(chessMatch.board, possibleMoves);

                Console.Write($"\nDestiny: ");
                Position destiny = Screen.ReadChessPosition().ToPosition();

                chessMatch.PlayMove(origin, destiny);
            }
        }
    }
}