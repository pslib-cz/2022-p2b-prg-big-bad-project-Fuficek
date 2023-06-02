using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    internal class King : ChessPiece, IMovable
    {
        public bool HasMoved { get; set; }
        public bool CanCastle { get; set; } = true;

        private readonly ChessBoard chessBoard;


        public King(bool isWhite, int position, ChessBoard chessBoard)
            : base(isWhite, position, isWhite ? 'K' : 'k')
        {
            HasMoved = false;
            this.chessBoard = chessBoard;
        }

        public override bool IsValidMove(int newPosition)
        {
            int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
            int colDifference = Math.Abs((newPosition % 8) - (Position % 8));

            // Kings can move one square in any direction
            if ((rowDifference == 1 && colDifference == 1) || (rowDifference == 1 && colDifference == 0) || (rowDifference == 0 && colDifference == 1))
            {
                return true;
            }

            // Check for castling
            if (colDifference == 2 && newPosition / 8 == Position / 8)
            {
                // Check if the rook is present in the correct position
                int rookPosition;
                int rookNewPosition;
                int rookColumn;
                if (newPosition % 8 > Position % 8)
                {
                    // King-side castling
                    rookPosition = (Position / 8) * 8 + 7;
                    rookNewPosition = rookPosition - 2;
                    rookColumn = 7;
                }
                else
                {
                    // Queen-side castling
                    rookPosition = (Position / 8) * 8;
                    rookNewPosition = rookPosition + 3;
                    rookColumn = 0;
                }
                ChessPiece? rook = chessBoard.GetPiece(rookPosition);
                if (rook is Rook && !((Rook)rook).HasMoved && rook.Position == rookPosition && rook.Position / 8 == newPosition / 8 && rook.Position % 8 == rookColumn)
                {
                    // Check if there are no pieces between the king and rook
                    int step = newPosition > Position ? 1 : -1;
                    for (int column = Position % 8 + step; column != rookColumn; column += step)
                    {
                        if (chessBoard.GetPiece(Position / 8 * 8 + column) != null)
                        {
                            return false;
                        }
                    }
                    rook.Position = rookNewPosition;
                    return true;
                }
            }
            return false;
        }


    }
}
