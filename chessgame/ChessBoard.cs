using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    internal class ChessBoard
    {
        public List<ChessPiece> Pieces { get; set; }
        public List<string> moves; // List to store the moves

        public ChessBoard()
        {
            Pieces = new List<ChessPiece>();
            moves = new List<string>();
        }

        public void SaveGameMoves(string filePath)
        {
            File.WriteAllLines(filePath, moves);
        }

        public bool IsKingCaptured(bool isWhite)
        {
            return Pieces.Any(piece => piece is King && piece.IsWhite == isWhite);
        }

        public bool MovePiece(int fromPosition, int toPosition)
        {
            ChessPiece? startPiece = GetPiece(fromPosition);
            ChessPiece? endPiece = GetPiece(toPosition);

            if (startPiece != null)
            {
                // Remove the end piece if it exists
                if (endPiece != null)
                {
                    Console.WriteLine(endPiece + " was captured");
                    Pieces.Remove(endPiece);
                }
                // Move the piece to the end position
                startPiece.Position = toPosition;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The move was legal");
                Console.ForegroundColor = ConsoleColor.White;

                return true;
            }
            return false;
        }

        public ChessPiece? GetPiece(int position)
        {
            return Pieces.Find(piece => piece.Position == position);
        }
    }
}
