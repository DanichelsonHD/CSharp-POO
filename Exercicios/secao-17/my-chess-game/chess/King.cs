using Secao17.board;

namespace Secao17.chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color) { }

        public override bool[,] ValidMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];
            int[,] moves = new int[,] {
                { -1, 0 }, { -1, 1 },
                { 0, 1 }, { 1, 1 },
                { 1, 0 }, { 1, -1 },
                { 0, -1 }, { -1, -1 }
            };
            Position position = new Position(0, 0);

            // Up
            if (OneMoveAtTime(-1, 0, position)) matrix[position.line, position.column] = true;

            // Right Up
            if (OneMoveAtTime(-1, 1, position)) matrix[position.line, position.column] = true;

            // Right
            if (OneMoveAtTime(0, 1, position)) matrix[position.line, position.column] = true;

            // Right Down
            if (OneMoveAtTime(1, 1, position)) matrix[position.line, position.column] = true;

            // Down
            if (OneMoveAtTime(1, 0, position)) matrix[position.line, position.column] = true;

            // Left Down
            if (OneMoveAtTime(1, -1, position)) matrix[position.line, position.column] = true;

            // Left
            if (OneMoveAtTime(0, -1, position)) matrix[position.line, position.column] = true;

            // Left Up
            if (OneMoveAtTime(-1, -1, position)) matrix[position.line, position.column] = true;

            return matrix;
        }
        public override string ToString()
        {
            return "K";
        }
    }
}