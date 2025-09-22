using Secao17.board;

namespace Secao17.chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "N";
        }
    }
}