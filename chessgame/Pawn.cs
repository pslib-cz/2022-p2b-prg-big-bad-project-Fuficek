using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    internal class Pawn : ChessPiece, IMovable
{
    public bool HasMoved { get; set; }
    private readonly ChessBoard chessBoard; // Instance variable

    public Pawn(bool isWhite, int position, ChessBoard chessBoard)
        : base(isWhite, position, isWhite ? 'P' : 'p')
    {
        HasMoved = false;
        this.chessBoard = chessBoard; // Initialize the instance variable
    }


    public override bool IsValidMove(int newPosition)
    {
        int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
        int colDifference = Math.Abs((newPosition % 8) - (Position % 8));

        if (IsWhite)
        {
            ChessPiece? piece = chessBoard.GetPiece(newPosition);
            // Pawns can only move forward
            if (newPosition < Position)
                return false;

            // Pawns can move one or two squares forward on their first move
            if (!HasMoved && rowDifference == 2 && colDifference == 0)
                if (piece != null)
                {
                    return false;
                }
                else return true;
            else if (rowDifference == 1 && colDifference == 0)
                if (piece != null)
                {
                    return false;
                }
                else return true;

            // Pawns can move diagonally to capture an opponent's piece
            if (rowDifference == 1 && colDifference == 1)
            {
                if (piece != null && piece.IsWhite != IsWhite && colDifference == 1) // Checking if the target position contains an opponent's piece and it's not in the same column
                    return true;
            }
        }
        else
        {
            ChessPiece? piece = chessBoard.GetPiece(newPosition);
            // Pawns can only move backward
            if (newPosition > Position)
                return false;

            // Pawns can move one or two squares backward on their first move
            if (!HasMoved && rowDifference == 2 && colDifference == 0)
                if (piece != null)
                {
                    return false;
                }
                else return true;
            else if (rowDifference == 1 && colDifference == 0)
                if (piece != null)
                {
                    return false;
                }
                else return true;

            // Pawns can move diagonally to capture an opponent's piece
            if (rowDifference == 1 && colDifference == 1)
            {
                if (piece != null && piece.IsWhite != IsWhite && colDifference == 1) // Checking if the target position contains an opponent's piece and it's not in the same column
                    return true;
            }
        }

        return false;
    }

}
}
