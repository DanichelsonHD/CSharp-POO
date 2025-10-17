using Secao17.board;

namespace Secao17.chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color, ChessMatch chessMatch) : base(board, color) => this.chessMatch = chessMatch;

        public override bool[,] ValidMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];
            int modifier = color == Color.White ? -1 : 1;
            var moves = new (int, int, bool)[] {
                (1,  0, false), (2,  0, false),
                (1,  1, true ), (1, -1, true )
            };

            foreach (var move in moves)
            {
                if (moveCount != 0 && move.Item1 == 2) continue;

                Position position = new Position(this.position.line, this.position.column);

                if (CanPawnMove(move.Item1 * modifier, move.Item2, move.Item3, position))
                    matrix[position.line, position.column] = true;
            }

            // #specialMove En Passant
            if (position.line == 3 && color == Color.White)
                matrix = enPassant(modifier, matrix);

            if (position.line == 4 && color == Color.Black)
                matrix = enPassant(modifier, matrix);

            return matrix;
        }
        public bool VerifyIfVulnerableEnPassant() 
            =>  ((color == Color.White && position.line == 4) || (color == Color.Black && position.line == 3)) &&
                moveCount == 1 && chessMatch.LastPieceMoved == this;
        private bool[,] enPassant(int modifier, bool[,] matrix)
        {
            Position left = new Position(position.line, position.column - 1);
            if (board.IsPositionValid(left)) matrix[left.line + modifier, left.column] = verifyEnPassant(left);

            Position right = new Position(position.line, position.column + 1);
            if (board.IsPositionValid(right)) matrix[right.line + modifier, right.column] = verifyEnPassant(right);

            return matrix;
        }
        private bool verifyEnPassant (Position position)
        {
            if (board.IsPositionValid(position) && board.IsPositionOccupied(position) == true && board.Piece(position) is Pawn)
            {
                Pawn pawn = (Pawn)board.Piece(position);
                if (pawn.VerifyIfVulnerableEnPassant()) return true;
            }
            return false;
        }
        private bool CanPawnMove(int line, int column, bool wantPieceThere, Position position)
            => OneMoveAtTime(line, column, position) && board.IsPositionOccupied(position) == wantPieceThere;
        public override string ToString()
        {
            return "P";
        }
    }
}