using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using chessgame;

class Program
{
    public static void Main()
    {
        // Set console encoding to UTF-8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Player player1 = new("Player 1", true);
        Player player2 = new("Player 2", false);

        int[] chessBoardPosition = new int[64];

        // Create the chess board
        ChessBoard ChessBoard = new();

        // Add white pieces
        ChessBoard.Pieces.Add(new King(true, 4, ChessBoard));
        ChessBoard.Pieces.Add(new Queen(true, 3, ChessBoard));
        ChessBoard.Pieces.Add(new Bishop(true, 2, ChessBoard));
        ChessBoard.Pieces.Add(new Bishop(true, 5, ChessBoard));
        ChessBoard.Pieces.Add(new Knight(true, 1));
        ChessBoard.Pieces.Add(new Knight(true, 6));
        ChessBoard.Pieces.Add(new Rook(true, 0, ChessBoard));
        ChessBoard.Pieces.Add(new Rook(true, 7, ChessBoard));
        // Add black pieces
        ChessBoard.Pieces.Add(new King(false, 60, ChessBoard));
        ChessBoard.Pieces.Add(new Queen(false, 59, ChessBoard));
        ChessBoard.Pieces.Add(new Bishop(false, 58, ChessBoard));
        ChessBoard.Pieces.Add(new Bishop(false, 61, ChessBoard));
        ChessBoard.Pieces.Add(new Knight(false, 57));
        ChessBoard.Pieces.Add(new Knight(false, 62));
        ChessBoard.Pieces.Add(new Rook(false, 56, ChessBoard));
        ChessBoard.Pieces.Add(new Rook(false, 63, ChessBoard));

        // Add white pawns
        for (int i = 8; i < 16; i++)
        {
            ChessBoard.Pieces.Add(new Pawn(true, i, ChessBoard));
        }

        // Add black pawns
        for (int i = 48; i < 56; i++)
        {
            ChessBoard.Pieces.Add(new Pawn(false, i, ChessBoard));
        }

        /* 
        // Prints out the position of all the pieces on the chessboard -- used for debugging purpouses
        foreach (ChessPiece piece in ChessBoard.Pieces)
        {
            Console.WriteLine($"{piece.Symbol} - Position: {piece.Position}");
        }
        */

        bool whiteToMove = true;
        while (ChessBoard.IsKingCaptured(true) && ChessBoard.IsKingCaptured(false))
        {
            PrintChessBoard(ChessBoard);
            if (whiteToMove is true)
            {
                bool moved = PlayerToMove(player1.Name, chessBoardPosition, ChessBoard, whiteToMove);
                if (moved is true) { whiteToMove = false; }
            }
            else if (whiteToMove is false)
            {
                bool moved = PlayerToMove(player2.Name, chessBoardPosition, ChessBoard, whiteToMove);
                if (moved is true) { whiteToMove = true; }
            }
        }
        Console.Clear();
        if (ChessBoard.IsKingCaptured(false) is true)
        {
            Console.WriteLine("Black player (player 2) wins!");
        }
        else if (ChessBoard.IsKingCaptured(true) is true)
        {
            Console.WriteLine("White player (player 1) wins!");
        }
        else
        {
            Console.WriteLine("It's a draw!");
        }
        bool savePosition = true;
        while (savePosition)
        {
            Console.WriteLine();
            Console.WriteLine("Enter the file name (or 'no' to not save the position):");
            string? fileName = Console.ReadLine();

            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    throw new ArgumentException("File name cannot be null or empty.");
                }

                if (fileName.ToLower() == "no")
                {
                    savePosition = false;
                    Console.WriteLine("Position not saved.");
                }
                else
                {
                    string filePath = fileName + ".txt";

                    if (File.Exists(filePath))
                    {
                        Console.WriteLine("File already exists. Choose a different file name.");
                    }
                    else
                    {
                        ChessBoard.SaveGameMoves(filePath);
                        Console.WriteLine("Game moves saved to: " + filePath);
                        savePosition = false;
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid input: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

    }
    static bool PlayerToMove(string name, int[] chessBoardPosition, ChessBoard chessBoard, bool whiteToMove)
    {
        Console.WriteLine($"{name}, enter your move (e.g.: e2 e4): ");
        try
        {
            string? input = Console.ReadLine();
            if (ProcessMoveInput(input, chessBoardPosition, chessBoard, whiteToMove) is false) { return false; }
            return true;
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message); return false;
        }
    }
    // method that processes the move input of the player, converts the string into a position and checks if the position is valid, if not
    static bool ProcessMoveInput(string? input, int[] chessBoardPosition, ChessBoard chessBoard, bool whiteToMove)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (input == null) { throw new ArgumentException("Input cannot be null."); }
            string[] parts = input.Split(' ');
            if (parts.Length != 2) { throw new ArgumentException("Invalid input format. Expected format: 'startPosition endPosition'."); }
            string startPosition = parts[0].Trim();
            string endPosition = parts[1].Trim();

            // Use regular expressions to validate the positions
            string pattern = @"^[a-h][1-8]$";
            if (!Regex.IsMatch(startPosition, pattern) || !Regex.IsMatch(endPosition, pattern))
            {
                throw new ArgumentException("Invalid input format. Expected format: 'rank'+'file', e.g. 'e4'.");
            }

            // Parse start position
            int startFile = char.ToUpper(startPosition[0]) - 'A';
            int startRank = int.Parse(startPosition[1].ToString()) - 1;
            int startIndex = (startRank * 8) + startFile;

            // Parse end position
            int endFile = char.ToUpper(endPosition[0]) - 'A';
            int endRank = int.Parse(endPosition[1].ToString()) - 1;
            int endIndex = (endRank * 8) + endFile;

            // Check if start position is valid
            if (startIndex < 0 || startIndex >= chessBoardPosition.Length)
            {
                throw new ArgumentException("Invalid start position.");
            }
            // Check if end position is valid
            if (endIndex < 0 || endIndex >= chessBoardPosition.Length)
            {
                throw new ArgumentException("Invalid end position.");
            }
            chessBoard.moves.Add(input);
            // Find the pieces
            ChessPiece? startPiece = chessBoard.Pieces.Find(p => p.Position == startIndex);
            ChessPiece? endPiece = chessBoard.Pieces.Find(p => p.Position == endIndex);
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Print the start and End position of the pieces:
            Console.WriteLine("________________________________________");
            Console.WriteLine("Info about the selected chess piece:");
            Console.WriteLine("Chess piece on start square: " + startPiece);
            Console.WriteLine("Chess piece on end square: " + endPiece);

            Console.WriteLine("________________________________________");
            if (startPiece != null && startPiece.IsWhite == whiteToMove)
            {
                if (endPiece != null && endPiece.IsWhite == startPiece.IsWhite)
                {
                    ThrowError("The move was illegal!"); return false;
                }
                // Check if the piece has a valid move to the end position
                if (startPiece.IsValidMove(endIndex))
                {   
                    chessBoard.MovePiece(startIndex, endIndex);
                    return true;
                }
                else ThrowError("The move was illegal!");return false;
            }
            else ThrowError("An error occurred: You canno't move the enemy player's pieces!");  return false;
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message); return false;
        }
    }
    // method that prints out the chessboard
    static void PrintChessBoard(ChessBoard Chessboard)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  ------------------------");

        for (int row = 1; row <= 8; row++)
        {
            Console.Write(0 + row + " ");
            for (int col = 'A'; col <= 'H'; col++)
            {
                int position = ((row - 1) * 8) + (col - 'A');

                // Print the chess piece in the current square
                Tuple<string, ConsoleColor> chessPiece = GetChessPieceOnSquare(position, Chessboard);
                Console.ForegroundColor = chessPiece.Item2;
                Console.Write(" " + chessPiece.Item1 + " ");
                Console.ForegroundColor = ConsoleColor.White;
                if (col == 'H') Console.Write("|");
            }
            Console.WriteLine();
            Console.WriteLine("  ------------------------");
        }

        Console.WriteLine("   A  B  C  D  E  F  G  H ");
    }

    // A method that returns the piece as a string and the color of the piece as ConsoleColor
    static Tuple<string, ConsoleColor> GetChessPieceOnSquare(int position, ChessBoard chessBoard)
    {
        foreach (ChessPiece piece in chessBoard.Pieces)
        {
            if (piece.Position == position)
            {

                return new Tuple<string, ConsoleColor>(piece.Symbol.ToString(), piece.IsWhite ? ConsoleColor.White : ConsoleColor.DarkGray); ;
            }
        }
        return new Tuple<string, ConsoleColor>(".", ConsoleColor.White); ;
    }

    public static int ConvertChessNotationToSquareNumber(string chessNotation)
    {
        if (chessNotation.Length != 2)
        {
            throw new ArgumentException("Invalid chess notation. Expected two characters.");
        }

        char fileChar = char.ToLower(chessNotation[0]);
        char rankChar = chessNotation[1];

        if (fileChar < 'a' || fileChar > 'h' || rankChar < '1' || rankChar > '8')
        {
            throw new ArgumentException("Invalid chess notation. Expected a valid file (a-h) and rank (1-8).");
        }

        int file = fileChar - 'a';
        int rank = rankChar - '1';

        return rank * 8 + file;
    }
    public static void ThrowError(string message){
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"An error occurred: " +message);
    }
}