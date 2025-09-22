using Secao17.board;

namespace Secao17.chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "Q";
        }
    }
}