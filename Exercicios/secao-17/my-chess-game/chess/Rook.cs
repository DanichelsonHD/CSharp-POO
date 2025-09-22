using Secao17.board;

namespace Secao17.chess
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "R";
        }
    }
}