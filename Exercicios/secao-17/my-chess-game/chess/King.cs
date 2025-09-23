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
            bool isValid;

            // Up
            isValid = OneMoveAtTime(-1, 0, position);
            matrix[position.line, position.column] = isValid;

            // Right Up
            isValid = OneMoveAtTime(-1, 1, position);
            matrix[position.line, position.column] = isValid;

            // Right
            isValid = OneMoveAtTime(0, 1, position);
            matrix[position.line, position.column] = isValid;

            // Right Down
            isValid = OneMoveAtTime(1, 1, position);
            matrix[position.line, position.column] = isValid;

            // Down
            isValid = OneMoveAtTime(1, 0, position);
            matrix[position.line, position.column] = isValid;

            // Left Down
            isValid = OneMoveAtTime(1, -1, position);
            matrix[position.line, position.column] = isValid;

            // Left
            isValid = OneMoveAtTime(0, -1, position);
            matrix[position.line, position.column] = isValid;

            // Left Up
            isValid = OneMoveAtTime(-1, -1, position);
            matrix[position.line, position.column] = isValid;

            return matrix;
        }
        public override string ToString()
        {
            return "K";
        }
    }
}