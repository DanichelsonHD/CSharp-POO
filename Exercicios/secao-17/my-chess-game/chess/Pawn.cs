using Secao17.board;

namespace Secao17.chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color) { }
        
        public override bool[,] ValidMoves()
        {
            bool[,] matrix = new bool[board.lines, board.columns];
            Position position = new Position(0, 0);
            int modifier = color == Color.White ? -1 : 1;

            // Up
            if (OneMoveAtTime(1 * modifier, 0, position) && !board.IsPositionOccupied(position)) 
                matrix[position.line, position.column] = true;

            // Double Up
            if (moveQuantity == 0 && OneMoveAtTime(2 * modifier, 0, position) && !board.IsPositionOccupied(position))
                matrix[position.line, position.column] = true;

            // Capture Right
            if (OneMoveAtTime(1 * modifier, 1, position) && board.IsPositionOccupied(position))
                matrix[position.line, position.column] = true;
            
            // Capture Left
            if (OneMoveAtTime(1 * modifier, -1, position) && board.IsPositionOccupied(position))
                matrix[position.line, position.column] = true;

            return matrix;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}