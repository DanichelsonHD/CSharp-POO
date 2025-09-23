using Secao17.board;

namespace Secao17.chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color) { }

        public override bool[,] ValidMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];
            var moves = new List<(int lineModifier, int columnModifier)>{
                ( 1, 2 ), ( 2, 1 ),
                ( -1, 2 ), ( -2, 1 ),
                ( 1, -2 ), ( 2, -1 ),
                ( -1, -2 ), ( -2, -1 )
            };
            Position position = new Position(0, 0);
            bool isValid;

            foreach (var (lineModifier, columnModifier) in moves)
            {
                isValid = OneMoveAtTime(lineModifier, columnModifier, position);
                matrix[position.line, position.column] = isValid;
            }

            return matrix;
        }
        public override string ToString()
        {
            return "N";
        }
    }
}