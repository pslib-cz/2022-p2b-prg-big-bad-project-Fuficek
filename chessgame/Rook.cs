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
            int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
            int colDifference = Math.Abs((newPosition % 8) - (Position % 8));

            // Rooks can move in rows or columns
            if (rowDifference == 0 || colDifference == 0)
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
                        // A piece is blocking the rook's path
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
