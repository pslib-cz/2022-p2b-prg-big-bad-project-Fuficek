using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    internal class Queen : ChessPiece, IMovable
    {
        private readonly ChessBoard chessBoard; // Instance variable

        public Queen(bool isWhite, int position, ChessBoard chessBoard)
            : base(isWhite, position, isWhite ? 'Q' : 'q')
        {
            this.chessBoard = chessBoard; // Initialize the instance variable
        }

        public override bool IsValidMove(int newPosition)
        {
            int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
            int colDifference = Math.Abs((newPosition % 8) - (Position % 8));

            // Queens can move in rows, columns, and diagonals
            if (rowDifference == 0 || colDifference == 0 || rowDifference == colDifference)
            {
                int rowDirection = Math.Sign(newPosition / 8 - Position / 8);
                int colDirection = Math.Sign(newPosition % 8 - Position % 8);

                int row = Position / 8 + rowDirection;
                int col = Position % 8 + colDirection;

                while (row != newPosition / 8 || col != newPosition % 8)
                {
                    ChessPiece? piece = chessBoard.GetPiece(row * 8 + col);
                    if (piece != null)
                    {
                        // A piece is blocking the queen's path
                        return false;
                    }

                    row += rowDirection;
                    col += colDirection;
                }
                return true;
            }

            return false;
        }
    }

}
