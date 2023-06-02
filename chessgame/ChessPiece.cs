using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    internal abstract class ChessPiece
    {
        public bool IsWhite { get; set; }
        public int Position { get; set; }
        public char Symbol { get; set; }

        public ChessPiece(bool isWhite, int position, char symbol)
        {
            IsWhite = isWhite;
            Position = position;
            Symbol = symbol;
        }
        public abstract bool IsValidMove(int newPosition);
    }
}
