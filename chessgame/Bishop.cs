using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    internal class Bishop : ChessPiece, IMovable
    {
        private readonly ChessBoard chessBoard;
        public Bishop(bool isWhite, int position, ChessBoard chessBoard)
            : base(isWhite, position, isWhite ? 'B' : 'n')
        {
            this.chessBoard = chessBoard;
            Symbol = isWhite ? 'B' : 'b';
        }
        public override bool IsValidMove(int newPosition)
        {
            int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
            int colDifference = Math.Abs((newPosition % 8) - (Position % 8));

            // Check if the new position is on the same diagonal
            if (rowDifference == colDifference)
            {
                int rowDirection = (newPosition / 8) > (Position / 8) ? 1 : -1;
                int colDirection = (newPosition % 8) > (Position % 8) ? 1 : -1;

                int row = Position / 8 + rowDirection;
                int col = Position % 8 + colDirection;

                while (row != newPosition / 8 && col != newPosition % 8)
                {
                    ChessPiece? piece = chessBoard.GetPiece(row * 8 + col);
                    if (piece != null)
                        return false;

                    row += rowDirection;
                    col += colDirection;
                }

                ChessPiece? destinationPiece = chessBoard.GetPiece(newPosition);
                return destinationPiece == null || destinationPiece.IsWhite != IsWhite;
            }

            return false;
        }

    }
}
