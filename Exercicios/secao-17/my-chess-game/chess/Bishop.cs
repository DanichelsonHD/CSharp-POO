using Secao17.board;

namespace Secao17.chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color) { }

        public override bool[,] ValidMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];
            Position position = new Position(0, 0);

            // Left Up
            matrix = SequentialMoves(-1, 1, position, matrix);

            // Right Up
            matrix = SequentialMoves(1, 1, position, matrix);

            // Right Down
            matrix = SequentialMoves(1, -1, position, matrix);

            // Left Down
            matrix = SequentialMoves(-1, -1, position, matrix);

            return matrix;
        }
        public override string ToString()
        {
            return "B";
        }
    }
}