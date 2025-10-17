using Secao17.board;

namespace Secao17.chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color) { }

        public override bool[,] ValidMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];
            List<int[]> moves = new List<int[]> {
                { [ 1,  0] }, { [ 0,  1] },
                { [-1,  0] }, { [ 0, -1] },
                { [-1,  1] }, { [ 1,  1] },
                { [ 1, -1] }, { [-1, -1] }
            };
            Position position = new Position(0, 0);

            return LineMoves(moves, position, matrix);
        }
        public override string ToString()
        {
            return "Q";
        }
    }
}