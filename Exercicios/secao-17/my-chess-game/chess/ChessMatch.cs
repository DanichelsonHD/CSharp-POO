using Secao17.board;

namespace Secao17.chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Check { get; private set; }
        public bool Ended { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public Piece LastPieceMoved { get; protected set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Ended = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();

            PlaceInitialPieces();
        }

        public Piece ExecuteMove(Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.AugmentmoveCount();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.PlacePiece(piece, destiny);
            if (capturedPiece != null) captured.Add(capturedPiece);

            // #specialMove Small Castling
            if (piece is King && destiny.column == origin.column + 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column + 3);
                Position rookDestiny = new Position(origin.line, origin.column + 1);
                Castling(rookOrigin, rookDestiny, false);
            }

            // #specialMove Big Castling
            if (piece is King && destiny.column == origin.column - 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column - 4);
                Position rookDestiny = new Position(origin.line, origin.column - 1);
                Castling(rookOrigin, rookDestiny, false);
            }
            
            // #specialMove En Passant
            if (piece is Pawn && destiny.column != origin.column && capturedPiece == null)
            {
                Position enemyPawn;
                if (piece.color == Color.White) enemyPawn = new Position(destiny.line + 1, destiny.column);
                else enemyPawn = new Position(destiny.line - 1, destiny.column);

                capturedPiece = board.RemovePiece(enemyPawn);
                captured.Add(capturedPiece);
            }

            return capturedPiece;
        }
        public void UndoMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece piece = board.RemovePiece(destiny);
            piece.DecreasemoveCount();
            if (capturedPiece != null)
            {
                board.PlacePiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            board.PlacePiece(piece, origin);

            // #specialMove Small Castling
            if (piece is King && destiny.column == origin.column + 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column + 3);
                Position rookDestiny = new Position(origin.line, origin.column + 1);
                Castling(rookDestiny, rookOrigin, true);
            }

            // #specialMove Big Castling
            if (piece is King && destiny.column == origin.column - 2)
            {
                Position rookOrigin = new Position(origin.line, origin.column - 4);
                Position rookDestiny = new Position(origin.line, origin.column - 1);
                Castling(rookDestiny, rookOrigin, true);
            }

            // #specialMove En Passant
            if (piece is Pawn && destiny.column != origin.column && capturedPiece == null)
            {
                Piece pawn = board.RemovePiece(destiny);
                Position pawnPosition;
                if (piece.color == Color.White) pawnPosition = new Position(3, destiny.column);
                else pawnPosition = new Position(4, destiny.column);

                board.PlacePiece(pawn, origin);
            }
        }
        private void Castling(Position origin, Position destiny, bool UndoCastling)
        {
            Piece rook = board.RemovePiece(origin);
            if (UndoCastling) rook.DecreasemoveCount();
            else rook.AugmentmoveCount();
            board.PlacePiece(rook, destiny);
        }
        public void PlayMove(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecuteMove(origin, destiny);

            if (IsInCheck(CurrentPlayer))
            {
                UndoMove(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check");
            }
            if (IsInCheck(adversary(CurrentPlayer))) Check = true;
            else Check = false;

            if (TestCheckmate(adversary(CurrentPlayer))) { Ended = true; Console.WriteLine($"Ended"); }
            else
            {
                Turn++;
                changePlayer();
            }

            LastPieceMoved = board.Piece(destiny);
        }
        public void ValidateOriginPosition(Position origin)
        {
            if (board.Piece(origin) == null) throw new BoardException("There isn't a piece in this position");
            if (CurrentPlayer != board.Piece(origin).color) throw new BoardException("This isn't your piece");
            if (!board.Piece(origin).existValidMoves()) throw new BoardException("No possible moves for this piece");
        }
        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!board.Piece(origin).possibleMove(destiny)) throw new BoardException("Invalid Position");
        }
        private void changePlayer()
        {
            if (CurrentPlayer == Color.White) CurrentPlayer = Color.Black;
            else CurrentPlayer = Color.White;
        }
        public HashSet<Piece> InGamePieces(Color color)
            => pieces.Where(piece => piece.color == color).Except(CapturedPieces(color)).ToHashSet();
        public HashSet<Piece> CapturedPieces(Color color)
            => captured.Where(piece => piece.color == color).ToHashSet();
        private Color adversary(Color color) => color == Color.White ? Color.Black : Color.White;
        private Piece king(Color color)
        {
            foreach (Piece piece in InGamePieces(color)) if (piece is King) return piece;
            return null;
        }
        public bool IsInCheck(Color color)
        {
            Piece k = king(color);
            if (k == null) throw new BoardException($"There is no {color} king");

            foreach (Piece piece in InGamePieces(adversary(color)))
            {
                bool[,] matrix = piece.ValidMoves();
                if (matrix[k.position.line, k.position.column]) return true;
            }
            return false;
        }
        public bool TestCheckmate(Color color)
        {
            if (!IsInCheck(color)) return false;
            foreach (Piece piece in InGamePieces(color))
            {
                bool[,] matrix = piece.ValidMoves();
                for (int i = 0; i < board.lines; i++)
                    for (int j = 0; j < board.columns; j++)
                        if (matrix[i, j])
                        {
                            Position origin = piece.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecuteMove(origin, destiny);
                            bool testCheck = IsInCheck(color);
                            UndoMove(origin, destiny, capturedPiece);
                            if (!testCheck) return false;
                        }

            }
            return true;
        }
        public void PlaceNewPiece(string position, Piece piece)
        {
            board.PlacePiece(piece, new ChessPosition(position).ToPosition());
            pieces.Add(piece);
        }
        public void PlaceInitialPieces()
        {
            //White Pieces
            PlaceNewPiece("a1", new Rook(board, Color.White));
            PlaceNewPiece("b1", new Knight(board, Color.White));
            PlaceNewPiece("c1", new Bishop(board, Color.White));
            PlaceNewPiece("d1", new Queen(board, Color.White));
            PlaceNewPiece("e1", new King(board, Color.White, this));
            PlaceNewPiece("f1", new Bishop(board, Color.White));
            PlaceNewPiece("g1", new Knight(board, Color.White));
            PlaceNewPiece("h1", new Rook(board, Color.White));

            //White Pawns
            for (int i = 0; i < board.columns; i++) PlaceNewPiece($"{(char)('a' + i)}2", new Pawn(board, Color.White, this));

            //Black Pieces
            PlaceNewPiece("a8", new Rook(board, Color.Black));
            PlaceNewPiece("b8", new Knight(board, Color.Black));
            PlaceNewPiece("c8", new Bishop(board, Color.Black));
            PlaceNewPiece("d8", new Queen(board, Color.Black));
            PlaceNewPiece("e8", new King(board, Color.Black, this));
            PlaceNewPiece("f8", new Bishop(board, Color.Black));
            PlaceNewPiece("g8", new Knight(board, Color.Black));
            PlaceNewPiece("h8", new Rook(board, Color.Black));

            //Black Pawns
            for (int i = 0; i < board.columns; i++) PlaceNewPiece($"{(char)('a' + i)}7", new Pawn(board, Color.Black, this));
        }
    }
}