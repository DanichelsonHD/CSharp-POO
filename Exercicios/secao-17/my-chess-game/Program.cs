using Secao17.board;
using Secao17.chess;

namespace Secao17.ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessMatch chessMatch = new ChessMatch();

            while (!chessMatch.Ended)
            {
                try
                {
                    Console.Clear();
                    Screen.PrintMatch(chessMatch);

                    Console.Write($"\nOrigin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    chessMatch.ValidateOriginPosition(origin);

                    Console.Clear();
                    bool[,] possibleMoves = chessMatch.board.Piece(origin).ValidMoves();
                    Screen.PrintBoard(chessMatch.board, possibleMoves);

                    Console.Write($"\nDestiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();
                    chessMatch.ValidateDestinyPosition(origin, destiny);

                    chessMatch.PlayMove(origin, destiny);
                }
                catch (BoardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Screen.PrintMatch(chessMatch);
        }
    }
}