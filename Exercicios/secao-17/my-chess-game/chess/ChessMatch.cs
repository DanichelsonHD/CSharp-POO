using Secao17.board;
using xadrez;

namespace Secao17.chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool ended { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            ended = false;

            PlaceInitialPieces();
        }

        public void PlayMove(Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.AugmentMoveQuantity();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.PlacePiece(piece, destiny);
        }
        public void PlaceInitialPieces()
        {
            //White Pieces
            board.PlacePiece(new Rook(board, Color.White), new ChessPosition("a1").ToPosition());
            board.PlacePiece(new Knight(board, Color.White), new ChessPosition("b1").ToPosition());
            board.PlacePiece(new Bishop(board, Color.White), new ChessPosition("c1").ToPosition());
            board.PlacePiece(new Queen(board, Color.White), new ChessPosition("d1").ToPosition());
            board.PlacePiece(new King(board, Color.White), new ChessPosition("e1").ToPosition());
            board.PlacePiece(new Bishop(board, Color.White), new ChessPosition("f1").ToPosition());
            board.PlacePiece(new Knight(board, Color.White), new ChessPosition("g1").ToPosition());
            board.PlacePiece(new Rook(board, Color.White), new ChessPosition("h1").ToPosition());

            //White Pawns
            board.PlacePiece(new Pawn(board, Color.White), new ChessPosition("a2").ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPosition("b2").ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPosition("c2").ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPosition("d2").ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPosition("e2").ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPosition("f2").ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPosition("g2").ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPosition("h2").ToPosition());

            //Black Pieces
            board.PlacePiece(new Rook(board, Color.Black), new ChessPosition("a8").ToPosition());
            board.PlacePiece(new Knight(board, Color.Black), new ChessPosition("b8").ToPosition());
            board.PlacePiece(new Bishop(board, Color.Black), new ChessPosition("c8").ToPosition());
            board.PlacePiece(new Queen(board, Color.Black), new ChessPosition("d8").ToPosition());
            board.PlacePiece(new King(board, Color.Black), new ChessPosition("e8").ToPosition());
            board.PlacePiece(new Bishop(board, Color.Black), new ChessPosition("f8").ToPosition());
            board.PlacePiece(new Knight(board, Color.Black), new ChessPosition("g8").ToPosition());
            board.PlacePiece(new Rook(board, Color.Black), new ChessPosition("h8").ToPosition());

            //Black Pawns
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPosition("a7").ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPosition("b7").ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPosition("c7").ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPosition("d7").ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPosition("e7").ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPosition("f7").ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPosition("g7").ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPosition("h7").ToPosition());
        }
    }
}