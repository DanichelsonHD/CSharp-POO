using Secao17.board;

namespace Secao17.chess
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color) { }

        public override bool[,] ValidMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];
            Position position = new Position(0, 0);

            // Up
            matrix = SequentialMoves(-1, 0, position, matrix);

            // Right
            matrix = SequentialMoves(0, 1, position, matrix);

            // Down
            matrix = SequentialMoves(1, 0, position, matrix);

            // Left
            matrix = SequentialMoves(0, -1, position, matrix);

            return matrix;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}