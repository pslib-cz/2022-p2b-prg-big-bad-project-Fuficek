using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    internal class Knight : ChessPiece, IMovable
    {
        public Knight(bool isWhite, int position)
            : base(isWhite, position, isWhite ? 'N' : 'n')
        {
        }

        public override bool IsValidMove(int newPosition)
        {
            // Check if the new position is a valid knight move
            int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
            int colDifference = Math.Abs((newPosition % 8) - (Position % 8));
            return (rowDifference == 2 && colDifference == 1) ||
                   (rowDifference == 1 && colDifference == 2);
        }
    }
}
