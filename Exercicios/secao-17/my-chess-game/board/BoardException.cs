using tabuleiro;

namespace Secao17.board
{
    class BoardException : Exception
    {
        public BoardException(string msg) : base(msg) {}
    }
}