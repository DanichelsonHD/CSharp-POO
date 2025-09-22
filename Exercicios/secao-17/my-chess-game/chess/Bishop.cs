using Secao17.board;

namespace Secao17.chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "B";
        }
    }
}