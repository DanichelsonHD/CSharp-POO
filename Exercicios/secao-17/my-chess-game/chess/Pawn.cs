using Secao17.board;

namespace Secao17.chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color) { }

        public override bool[,] ValidMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];
            Position position = new Position(0, 0);
            bool isValid;

            // Up
            isValid = OneMoveAtTime(-1, 0, position);
            matrix[position.line, position.column] = isValid;

            // Double Up
            if (moveQuantity == 0)
            {
                isValid = OneMoveAtTime(-2, 0, position);
                matrix[position.line, position.column] = isValid;
            }

            return matrix;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}