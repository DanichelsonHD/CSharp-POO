using Secao17.board;

namespace Secao17.chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool ended { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            ended = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();

            PlaceInitialPieces();
        }

        public void ExecuteMove(Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.AugmentMoveQuantity();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.PlacePiece(piece, destiny);
            if (capturedPiece != null) captured.Add(capturedPiece);
        }
        public void PlayMove(Position origin, Position destiny)
        {
            ExecuteMove(origin, destiny);
            turn++;
            changePlayer();
        }
        public void ValidateOriginPosition(Position origin)
        {
            if (board.Piece(origin) == null) throw new BoardException("There isn't a piece in this position");
            if (currentPlayer != board.Piece(origin).color) throw new BoardException("This isn't your piece");
            if (!board.Piece(origin).existValidMoves()) throw new BoardException("No possible moves for this piece");
        }
        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!board.Piece(origin).canMoveTo(destiny)) throw new BoardException("Invalid Position");
        }
        private void changePlayer()
        {
            if (currentPlayer == Color.White) currentPlayer = Color.Black;
            else currentPlayer = Color.White;
        }
        public HashSet<Piece> inGamePieces(Color color)
            => pieces.Where(piece => piece.color == color).Except(capturedPieces(color)).ToHashSet();
        public HashSet<Piece> capturedPieces(Color color)
            => captured.Where(piece => piece.color == color).ToHashSet();
        public void placeNewPiece(string position, Piece piece)
        {
            board.PlacePiece(piece, new ChessPosition(position).ToPosition());
            pieces.Add(piece);
        }
        public void PlaceInitialPieces()
        {
            //White Pieces
            placeNewPiece("a1", new Rook(board, Color.White));
            placeNewPiece("b1", new Knight(board, Color.White));
            placeNewPiece("c1", new Bishop(board, Color.White));
            placeNewPiece("d1", new Queen(board, Color.White));
            placeNewPiece("e1", new King(board, Color.White));
            placeNewPiece("f1", new Bishop(board, Color.White));
            placeNewPiece("g1", new Knight(board, Color.White));
            placeNewPiece("h1", new Rook(board, Color.White));

            //White Pawns
            for (int i = 0; i < board.columns; i++) placeNewPiece($"{(char)('a' + i)}2", new Pawn(board, Color.White));

            //Black Pieces
            placeNewPiece("a8", new Rook(board, Color.Black));
            placeNewPiece("b8", new Knight(board, Color.Black));
            placeNewPiece("c8", new Bishop(board, Color.Black));
            placeNewPiece("d8", new Queen(board, Color.Black));
            placeNewPiece("e8", new King(board, Color.Black));
            placeNewPiece("f8", new Bishop(board, Color.Black));
            placeNewPiece("g8", new Knight(board, Color.Black));
            placeNewPiece("h8", new Rook(board, Color.Black));

            //Black Pawns
            //for (int i = 0; i < board.columns; i++) placeNewPiece($"{(char)('a' + i)}7", new Pawn(board, Color.Black));
        }
    }
}