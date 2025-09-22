namespace Secao17.board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column) => pieces[line, column];
        public Piece Piece(Position position) => pieces[position.line, position.column];
        public bool IsPositionOccupied(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }
        public void PlacePiece(Piece piece, Position position)
        {
            if (IsPositionOccupied(position)) throw new BoardException("A piece is already placed in this position.");
            pieces[position.line, position.column] = piece;
            piece.position = position;
        }
        public Piece RemovePiece(Position position)
        {
            if (Piece(position) == null) return null;
            Piece buffer = Piece(position);
            buffer.position = null;
            pieces[position.line, position.column] = null;
            return buffer;
        }

        public bool IsPositionValid(Position position)
        {
            if (position.line > lines || position.line < 0 || position.column > columns || position.column < 0) return false;
            return true;
        }
        public void ValidatePosition(Position position)
        {
            if (!IsPositionValid(position)) throw new BoardException("Invalid position.");
        }
    }
}