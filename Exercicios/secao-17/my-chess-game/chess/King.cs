using Secao17.board;

namespace Secao17.chess
{
    class King : Piece
    {
        public King(Board board, Color color, ChessMatch chessMatch) : base(board, color)
            => this.chessMatch = chessMatch;

        public override bool[,] ValidMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];
            List<int[]> moves = new List<int[]> {
                { [-1,  0] }, { [-1,  1] },
                { [ 0,  1] }, { [ 1,  1] },
                { [ 1,  0] }, { [ 1, -1] },
                { [ 0, -1] }, { [-1, -1] }
            };
            Position position = new Position(0, 0);
            
            SingleMoves(moves, position, matrix);
            position = this.position;

            // #specialMove Castling
            if (moveCount == 0 && !chessMatch.Check)
            {
                // Small Castling
                Position rightRook = new Position(position.line, position.column + 3);
                if (testRookForCastling(rightRook))
                {
                    Position newRookPosition = new Position(position.line, position.column + 1);
                    Position newKingPosition = new Position(position.line, position.column + 2);
                    if (board.Piece(newKingPosition) == null && board.Piece(newRookPosition) == null) matrix[position.line, position.column + 2] = true;
                }

                // Big Castling
                Position leftRook = new Position(position.line, position.column - 4);
                if (testRookForCastling(leftRook))
                {
                    Position newRookPosition = new Position(position.line, position.column - 1);
                    Position newKingPosition = new Position(position.line, position.column - 2);
                    Position lastPosition = new Position(position.line, position.column - 3);
                    if (board.Piece(newKingPosition) == null && board.Piece(newRookPosition) == null && board.Piece(lastPosition) == null)
                        matrix[position.line, position.column - 2] = true;
                }
            }

            return matrix;
        }
        private bool testRookForCastling(Position position)
        {
            Piece rook = board.Piece(position);
            return rook != null && rook is Rook && rook.color == color && rook.moveCount == 0;
        }
        public override string ToString()
        {
            return "K";
        }
    }
}