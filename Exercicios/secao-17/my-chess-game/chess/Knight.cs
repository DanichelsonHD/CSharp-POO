using Secao17.board;

namespace Secao17.chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color) { }

        public override bool[,] ValidMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];
            Position position = new Position(0, 0);
            bool isValid;

            // Right Down
            if (OneMoveAtTime(1, 2, position)) matrix[position.line, position.column] = true;

            if (OneMoveAtTime(2, 1, position)) matrix[position.line, position.column] = true;

            // Right Up
            if (OneMoveAtTime(-1, 2, position)) matrix[position.line, position.column] = true;

            if (OneMoveAtTime(-2, 1, position)) matrix[position.line, position.column] = true;

            // Left Down
            if (OneMoveAtTime(1, -2, position)) matrix[position.line, position.column] = true;

            if (OneMoveAtTime(2, -1, position)) matrix[position.line, position.column] = true;

            // Left Up
            if (OneMoveAtTime(-1, -2, position)) matrix[position.line, position.column] = true;

            if (OneMoveAtTime(-2, -1, position)) matrix[position.line, position.column] = true;

            return matrix;
        }
        public override string ToString()
        {
            return "N";
        }
    }
}