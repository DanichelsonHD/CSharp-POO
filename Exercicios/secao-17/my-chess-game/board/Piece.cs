namespace Secao17.board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int moveQuantity { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.color = color;
            this.board = board;
            moveQuantity = 0;
        }
        protected bool CanMove(Position position)
        {
            if (!board.IsPositionValid(position)) return false;
            Piece piece = board.Piece(position);
            return piece == null || piece.color != color;
        }
        protected bool OneMoveAtTime(int lineModifier, int columnModifier, Position position)
        {
            if (!board.IsPositionValid(new Position(this.position.line + lineModifier, this.position.column + columnModifier))) return false;
            position.DefineValues(this.position.line + lineModifier, this.position.column + columnModifier);
            if (board.IsPositionValid(position) && CanMove(position)) return true;
            return false;
        }
        protected bool[,] SequentialMoves(int lineModifier, int columnModifier, Position position, bool[,] matrix)
        {
            position.DefineValues(this.position.line + lineModifier, this.position.column + columnModifier);
            while (board.IsPositionValid(position) && CanMove(position))
            {
                matrix[position.line, position.column] = true;
                Piece piece = board.Piece(position);
                if (piece != null && piece.color != color) break;

                position.line += lineModifier;
                position.column += columnModifier;
            }
            return matrix;
        }
        public void AugmentMoveQuantity() => moveQuantity++;
        public void DecreaseMoveQuantity() => moveQuantity--;
        public bool existValidMoves()
        {
            bool[,] mat = ValidMoves();
            for (int i = 0; i < board.lines; i++)
                for (int j = 0; j < board.columns; j++)
                    if (mat[i, j]) return true;
            return false;
        }
        public bool possibleMove(Position position)
        {
            return ValidMoves()[position.line, position.column];
        }
        public abstract bool[,] ValidMoves();
    }
}