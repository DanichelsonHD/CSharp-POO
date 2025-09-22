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
        public void PutPiece(Piece piece, Position position)
        {
            pieces[position.line, position.column] = piece;
            piece.position = position;
        }
    }
}