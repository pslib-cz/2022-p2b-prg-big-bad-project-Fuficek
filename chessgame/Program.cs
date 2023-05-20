/* LÁTKA PROBRANÁ ZA TENTO ŠKOLNÍ ROK, A ZDA BYLA VYUŽITA
 * [X] POLE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Array.aspx
 * [X] TŘÍDY A OBJEKTY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Class.aspx
 * [X] VÝJIMKY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Exception.aspx
 * [X] DĚDIČNOST - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Inheritence.aspx
 * [X] ZAPOUZDŘENÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Encapsulation.aspx
 * [X] POLYMORFISMUS - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Polymorphism.aspx
 * [X] STATICKÉ TŘÍDY A ČLENY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Static.aspx
 * [X] ABSTRAKCE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Abstraction.aspx
 * [X] ROZHRANÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Interface.aspx
 * [ ] PŘETÍŽENÍ OPERÁTORŮ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-OperatorOverloading.aspx
 * [ ] STRUKTURA - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Struct.aspx
 * [ ] ZÁZNAM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Record.aspx
 * [X] S.O.L.I.D. - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-SOLID.aspx
 * [ ] GERERIKA - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Generics.aspx
 * [ ] KOLEKCE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Collection.aspx
 * [X] SEZNAM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Col-List.aspx
 * [ ] SLOVNÍK - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Dictionary.aspx
 * [ ] FRONTA - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Queue.aspx
 * [ ] ZÁSOBNÍK - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Stack.aspx
 * [ ] DELEGÁTY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Delegates.aspx
 * [ ] ROZŠIŘUJÍCÍ METODY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-ExtensionMethods.aspx
 * [ ] LINQ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-LINQ.aspx
 * [ ] DATUM A ČAS - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-DateTime.aspx
 * [ ] STOPKY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Stopwatch.aspx
 * [ ] TESTOVÁNÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Testing.aspx
 * [ ] JEDNOTKOVÉ TESTOVÁNÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-UnitTesting.aspx
 * [ ] BENCHMARK - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Benchmark.aspx
 * [ ] ŘETĚZCE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-String.aspx
 * [X] REGEX - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-RegularExpression.aspx
 * [ ] SOUBOROVÝ SYSTÉM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-FileSystem.aspx
 * [ ] ARGS - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-CommandLineArgs.aspx
 * [ ] TEXTOVÉ SOUBORY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-TextFile.aspx
 * [ ] BINÁRNÍ SOUBORY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-BinaryFile.aspx
 * [ ] ŠIFROVÁNÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Ciphers.aspx
 * [ ] AES - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-AES.aspx
 * [ ] RSA - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-RSA.aspx
 * [ ] HASHOVÁNÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Hash.aspx
 * [ ] SPOJOVÝ SEZNAM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-LinkedList.aspx
 * [ ] BINÁRNÍ STROM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-BinaryTree.aspx
 * [X] VÝSTUP NA KONZOLI - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Console.aspx
*/


/* ======== TODO ========
 * logging the game moves into a text file - e4 e5, Nf3 f5, d4 Nf6, .. ..
 * allow the players to change their names
 * implement the mechanic of checks
 * en passant
 * casteling
 */

using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

interface IMovable
{
    bool IsValidMove(int newPosition);
}
abstract class ChessPiece
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

class Pawn : ChessPiece, IMovable
{
    public bool HasMoved { get; set; }
    private ChessBoard chessBoard; // Instance variable

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

class Queen : ChessPiece, IMovable
{
    public Queen(bool isWhite, int position)
        : base(isWhite, position, isWhite ? 'Q' : 'q')
    {
    }

    public override bool IsValidMove(int newPosition)
    {
        int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
        int colDifference = Math.Abs((newPosition % 8) - (Position % 8));

        // Queens can move like a bishop or a rook
        return rowDifference == colDifference || (rowDifference == 0 || colDifference == 0);
    }
}

class King : ChessPiece, IMovable
{
    public bool HasMoved { get; set; }

    public King(bool isWhite, int position)
        : base(isWhite, position, isWhite ? 'K' : 'k')
    {
        HasMoved = false;
    }

    public override bool IsValidMove(int newPosition)
    {
        int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
        int colDifference = Math.Abs((newPosition % 8) - (Position % 8));

        // Kings can move one square in any direction
        if ((rowDifference == 1 && colDifference == 1) || (rowDifference == 1 && colDifference == 0) || (rowDifference == 0 && colDifference == 1))
            return true;

        // Kings can castle with a rook if they haven't moved
        if (!HasMoved && newPosition == Position + 2 && colDifference == 2)
            return true;
        if (!HasMoved && newPosition == Position - 2 && colDifference == 2)
            return true;

        return false;
    }
}

class Rook : ChessPiece, IMovable
{
    public bool HasMoved { get; set; }

    public Rook(bool isWhite, int position)
        : base(isWhite, position, isWhite ? 'R' : 'r')
    {
        HasMoved = false;
    }

    public override bool IsValidMove(int newPosition)
    {
        // Check if the new position is on the same row or column
        int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
        int colDifference = Math.Abs((newPosition % 8) - (Position % 8));
        return rowDifference == 0 || colDifference == 0;
    }
}


class Knight : ChessPiece, IMovable
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

class Bishop : ChessPiece, IMovable
{
    public Bishop(bool isWhite, int position) 
        : base(isWhite, position, isWhite ? 'B' : 'n')
    {
        Symbol = isWhite ? 'B' : 'b';
    }
    public override bool IsValidMove(int newPosition)
    {
        // Check if the new position is on the same diagonal
        int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
        int colDifference = Math.Abs((newPosition % 8) - (Position % 8));
        return rowDifference == colDifference;
    }
}
class ChessBoard
{
    public List<ChessPiece> Pieces { get; set; }

    public ChessBoard()
    {
        Pieces = new List<ChessPiece>();
    }

    public ChessPiece? GetPiece(int position)
    {
        return Pieces.Find(piece => piece.Position == position);
    }
}

class Player
{
    public string Name { get; set; }
    public bool IsWhite { get; set; }

    public Player(string name, bool isWhite)
    {
        Name = name;
        IsWhite = isWhite;
    }
}
class Program
{
    public static void Main(string[] args)
    {
        // Set console encoding to UTF-8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Player player1 = new("Player 1", true);
        Player player2 = new("Player 2", false);

        int[] chessBoardPosition = new int[64];

        // Create the chess board
        ChessBoard ChessBoard = new ChessBoard();

        // Add white pieces
        ChessBoard.Pieces.Add(new King(true, 4));
        ChessBoard.Pieces.Add(new Queen(true, 3));
        ChessBoard.Pieces.Add(new Bishop(true, 2));
        ChessBoard.Pieces.Add(new Bishop(true, 5));
        ChessBoard.Pieces.Add(new Knight(true, 1));
        ChessBoard.Pieces.Add(new Knight(true, 6));
        ChessBoard.Pieces.Add(new Rook(true, 0));
        ChessBoard.Pieces.Add(new Rook(true, 7));
        // Add black pieces
        ChessBoard.Pieces.Add(new King(false, 60));
        ChessBoard.Pieces.Add(new Queen(false, 59));
        ChessBoard.Pieces.Add(new Bishop(false, 58));
        ChessBoard.Pieces.Add(new Bishop(false, 61));
        ChessBoard.Pieces.Add(new Knight(false, 57));
        ChessBoard.Pieces.Add(new Knight(false, 62));
        ChessBoard.Pieces.Add(new Rook(false, 56));
        ChessBoard.Pieces.Add(new Rook(false, 63));

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


        foreach (ChessPiece piece in ChessBoard.Pieces)
        {
            Console.WriteLine($"{piece.Symbol} - Position: {piece.Position}");
        }

        bool whiteToMove = true;
        while (true)
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            // Print the start and End position of the pieces:
            Console.WriteLine("________________________________________");
            Console.WriteLine("Info about the selected chess piece:");
            Console.WriteLine("Chess piece on start square: " + GetChessPieceOnSquare(ConvertChessNotationToSquareNumber(startPosition), chessBoard));
            Console.WriteLine("Chess piece on start square: " + GetChessPieceOnSquare(ConvertChessNotationToSquareNumber(endPosition), chessBoard));

            // Find the piece at the start position
            ChessPiece? piece = chessBoard.Pieces.Find(p => p.Position == startIndex);
            Console.WriteLine(piece);
            Console.WriteLine("________________________________________");
            if (piece != null && piece.IsWhite == whiteToMove)
            {
                // Check if the piece has a valid move to the end position
                if (piece.IsValidMove(endIndex))
                {
                    // Move the piece to the end position
                    piece.Position = endIndex;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The move was legal");
                    Console.ForegroundColor = ConsoleColor.White;
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