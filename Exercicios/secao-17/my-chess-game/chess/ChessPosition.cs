using Secao17.board;

namespace Secao17.chess
{
    class ChessPosition
    {
        public Char column { get; set; }
        public int line { get; set; }

        public ChessPosition(Char column, int line)
        {
            this.column = column;
            this.line = line;
        }
        public ChessPosition(string position)
        {
            this.column = position[0];
            this.line = int.Parse($"{position[1]}");
        }

        public Position ToPosition() => new Position(8 - line, column - 'a');
        public override string ToString()
        {
            return $"{column}{line}";
        }
    }
}