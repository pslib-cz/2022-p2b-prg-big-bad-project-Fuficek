using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    internal class Rook : ChessPiece, IMovable
    {
        public bool HasMoved { get; set; }
        private readonly ChessBoard chessBoard;
        public bool CanCastle { get; set; } = true;


        public Rook(bool isWhite, int position, ChessBoard chessBoard)
            : base(isWhite, position, isWhite ? 'R' : 'r')
        {
            HasMoved = false;
            this.chessBoard = chessBoard;
        }

        public override bool IsValidMove(int newPosition)
        {
            // Check if the new position is on the same row or column
            int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
            int colDifference = Math.Abs((newPosition % 8) - (Position % 8));

            if (rowDifference == 0 || colDifference == 0)
            {
                int step = rowDifference > 0 ? 8 : 1; // Define the step size based on the direction

                // Check for any pieces in the path
                int currentPos = Position + step;
                while (currentPos != newPosition)
                {
                    ChessPiece? piece = chessBoard.GetPiece(currentPos);
                    if (piece != null)
                    {
                        // There is a piece in the path, invalid move
                        return false;
                    }
                    currentPos += step;
                }

                return true;
            }

            return false;
        }

    }
}
