/* LÁTKA PROBRANÁ ZA TENTO ŠKOLNÍ ROK, A ZDA BYLA VYUŽITA
 * [X] POLE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Array.aspx
 * [X] TŘÍDY A OBJEKTY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Class.aspx
 * [X] VÝJIMKY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Exception.aspx
 * [X] DĚDIČNOST - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Inheritence.aspx
 * [X] ZAPOUZDŘENÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Encapsulation.aspx
 * [X] POLYMORFISMUS - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Polymorphism.aspx
 * [X] STATICKÉ TŘÍDY A ČLENY - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Static.aspx
 * [X] ABSTRAKCE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Abstraction.aspx
 * [ ] ROZHRANÍ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Interface.aspx
 * [ ] PŘETÍŽENÍ OPERÁTORŮ - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-OperatorOverloading.aspx
 * [ ] STRUKTURA - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Struct.aspx
 * [ ] ZÁZNAM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Record.aspx
 * [X] S.O.L.I.D. - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-SOLID.aspx
 * [ ] GERERIKA - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Generics.aspx
 * [ ] KOLEKCE - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Collection.aspx
 * [ ] SEZNAM - https://pslib.sharepoint.com/sites/studium/prg/SitePages/CSharp-Col-List.aspx
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
 * actually make the moves on the board
 * implement the mechanic of checks
 * en passant
 * casteling
 */
using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

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
}

class Pawn : ChessPiece
{
    public bool HasMoved { get; set; }

    public Pawn(bool isWhite, int position)
        : base(isWhite, position, isWhite ? 'P' : 'p')
    {
        HasMoved = false;
    }

    public bool IsValidMove(int newPosition)
    {
        int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
        int colDifference = Math.Abs((newPosition % 8) - (Position % 8));

        if (IsWhite)
        {
            // Pawns can only move forward
            if (newPosition < Position)
                return false;

            // Pawns can move one or two squares forward on their first move
            if (!HasMoved && rowDifference == 2 && colDifference == 0)
                return true;
            else if (rowDifference == 1 && colDifference == 0)
                return true;

            // Pawns can move diagonally to capture an opponent's piece
            if (rowDifference == 1 && colDifference == 1)
                return true;
        }
        else
        {
            // Pawns can only move backward
            if (newPosition > Position)
                return false;

            // Pawns can move one or two squares backward on their first move
            if (!HasMoved && rowDifference == 2 && colDifference == 0)
                return true;
            else if (rowDifference == 1 && colDifference == 0)
                return true;

            // Pawns can move diagonally to capture an opponent's piece
            if (rowDifference == 1 && colDifference == 1)
                return true;
        }

        return false;
    }
}

class Queen : ChessPiece
{
    public Queen(bool isWhite, int position)
        : base(isWhite, position, isWhite ? 'Q' : 'q')
    {
    }

    public bool IsValidMove(int newPosition)
    {
        int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
        int colDifference = Math.Abs((newPosition % 8) - (Position % 8));

        // Queens can move like a bishop or a rook
        return rowDifference == colDifference || (rowDifference == 0 || colDifference == 0);
    }
}

class King : ChessPiece
{
    public bool HasMoved { get; set; }

    public King(bool isWhite, int position)
        : base(isWhite, position, isWhite ? 'K' : 'k')
    {
        HasMoved = false;
    }

    public bool IsValidMove(int newPosition)
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

class Rook : ChessPiece
{
    public bool HasMoved { get; set; }

    public Rook(bool isWhite, int position)
        : base(isWhite, position, isWhite ? 'R' : 'r')
    {
        HasMoved = false;
    }

    public bool IsValidMove(int newPosition)
    {
        // Check if the new position is on the same row or column
        int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
        int colDifference = Math.Abs((newPosition % 8) - (Position % 8));
        return rowDifference == 0 || colDifference == 0;
    }
}


class Knight : ChessPiece
{
    public Knight(bool isWhite, int position)
        : base(isWhite, position, isWhite ? 'N' : 'n')
    {
    }

    public bool IsValidMove(int newPosition)
    {
        // Check if the new position is a valid knight move
        int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
        int colDifference = Math.Abs((newPosition % 8) - (Position % 8));
        return (rowDifference == 2 && colDifference == 1) ||
               (rowDifference == 1 && colDifference == 2);
    }
}

class Bishop : ChessPiece
{
    public Bishop(bool isWhite, int position) 
        : base(isWhite, position, isWhite ? 'B' : 'n')
    {
        Symbol = isWhite ? 'B' : 'b';
    }
    public bool IsValidMove(int newPosition)
    {
        // Check if the new position is on the same diagonal
        int rowDifference = Math.Abs((newPosition / 8) - (Position / 8));
        int colDifference = Math.Abs((newPosition % 8) - (Position % 8));
        return rowDifference == colDifference;
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

        int[] chessBoard = new int[64];

        for (int i = 0; i < chessBoard.Length; i++)
        {
            chessBoard[i] = i;
        }
        Pawn[] pawns = new Pawn[16];

        // Initialize white pieces
        King whiteKing = new(true, 4);
        Queen whiteQueen = new(true, 3);
        Bishop whiteBishop1 = new(true, 2);
        Bishop whiteBishop2 = new(true, 5);
        Knight whiteKnight1 = new(true, 1);
        Knight whiteKnight2 = new(true, 6);
        Rook whiteRook1 = new(true, 0);
        Rook whiteRook2 = new(true, 7);

        // Initialize black pieces
        King blackKing = new(false, 60);
        Queen blackQueen = new(false, 59);
        Bishop blackBishop1 = new(false, 58);
        Bishop blackBishop2 = new(false, 61);
        Knight blackKnight1 = new(false, 57);
        Knight blackKnight2 = new(false, 62);
        Rook blackRook1 = new(false, 56);
        Rook blackRook2 = new(false, 63);

        // Initialize white pawns in second row
        for (int i = 0; i < 8; i++)
        {
            pawns[i] = new Pawn(true, i + 8);
        }

        // Initialize black pawns in seventh row
        for (int i = 0; i < 8; i++)
        {
            pawns[i + 8] = new Pawn(false, i + 48);
        }



        bool whiteToMove = true;
        while (true)
        {
            //Console.WriteLine("There is: " + GetChessPieceOnSquare("c8", pawns, whiteKing, whiteQueen, whiteBishop1, whiteBishop2, whiteKnight1, whiteKnight2, whiteRook1, whiteRook2, blackKing, blackQueen, blackBishop1, blackBishop2, blackKnight1, blackKnight2, blackRook1, blackRook2)); 
            PrintChessBoard(chessBoard, pawns,whiteKing, whiteQueen, whiteBishop1, whiteBishop2,whiteKnight1,whiteKnight2,whiteRook1, whiteRook2,blackKing, blackQueen, blackBishop1,blackBishop2, blackKnight1, blackKnight2, blackRook1, blackRook2);
            if (whiteToMove is true)
            {
                bool moved = PlayerToMove(player1.Name, chessBoard);
                if (moved is true) { whiteToMove = false; }
            }
            else if (whiteToMove is false)
            {
                bool moved = PlayerToMove(player2.Name, chessBoard);
                if (moved is true) { whiteToMove = true; }
            }
        }
    }
    static bool PlayerToMove(string name, int[] chessboard)
    {
        Console.WriteLine($"{name}, enter your move (e.g.: e7 e5): ");
        try
        {
            string? input = Console.ReadLine();
            if (processMoveInput(input, chessboard) is false) { return false; }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false;
        }
    }
    // method that processes the move input of the player, converts the string into a position and checks if the position is valid, if not
    static bool processMoveInput(string? input, int[] chessboard)
    {
        try
        {
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
            if (startIndex < 0 || startIndex >= chessboard.Length)
            {
                throw new ArgumentException("Invalid start position.");
            }
            // Check if end position is valid
            if (endIndex < 0 || endIndex >= chessboard.Length)
            {
                throw new ArgumentException("Invalid end position.");
            }

            // TODO: Process the move

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false;
        }
    }
    // method that prints out the chessboard
    static void PrintChessBoard(int[] chessBoard, Pawn[] pawns, King whiteKing, Queen whiteQueen, Bishop whiteBishop1, Bishop whiteBishop2, Knight whiteKnight1, Knight whiteKnight2, Rook whiteRook1, Rook whiteRook2, King blackKing, Queen blackQueen, Bishop blackBishop1, Bishop blackBishop2, Knight blackKnight1, Knight blackKnight2, Rook blackRook1, Rook blackRook2)
    {
        Console.WriteLine("  ------------------------");

        for (int row = 1; row <= 8; row++)
        {
            Console.Write(0 + row + " ");
            for (int col = 'A'; col <= 'H'; col++)
            {
                int position = ((row - 1) * 8) + (col - 'A');

                // Print the chess piece in the current square
                Tuple<string, ConsoleColor> chessPiece = GetChessPieceOnSquare(position, pawns, whiteKing, whiteQueen, whiteBishop1, whiteBishop2, whiteKnight1, whiteKnight2, whiteRook1, whiteRook2, blackKing, blackQueen, blackBishop1, blackBishop2, blackKnight1, blackKnight2, blackRook1, blackRook2);
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
    static Tuple<string, ConsoleColor> GetChessPieceOnSquare(int position, Pawn[] pawns, King whiteKing, Queen whiteQueen, Bishop whiteBishop1, Bishop whiteBishop2, Knight whiteKnight1, Knight whiteKnight2, Rook whiteRook1, Rook whiteRook2, King blackKing, Queen blackQueen, Bishop blackBishop1, Bishop blackBishop2, Knight blackKnight1, Knight blackKnight2, Rook blackRook1, Rook blackRook2)
    {
        // Print the chess piece in the current square
        if (whiteKing.Position == position) { return new Tuple<string, ConsoleColor>("K", ConsoleColor.White); }
        else if (whiteQueen.Position == position) { return new Tuple<string, ConsoleColor>("Q", ConsoleColor.White); }
        else if (whiteBishop1.Position == position || whiteBishop2.Position == position) { return new Tuple<string, ConsoleColor>("B", ConsoleColor.White); }
        else if (whiteKnight1.Position == position || whiteKnight2.Position == position) { return new Tuple<string, ConsoleColor>("N", ConsoleColor.White); }
        else if (whiteRook1.Position == position || whiteRook2.Position == position) { return new Tuple<string, ConsoleColor>("R", ConsoleColor.White); }
        else
        {
            foreach (Pawn pawn in pawns)
            {
                if (pawn.Position == position) { return new Tuple<string, ConsoleColor>(pawn.IsWhite ? "P" : "p", pawn.IsWhite ? ConsoleColor.White : ConsoleColor.DarkGray); }
            }

            if (blackKing.Position == position) { return new Tuple<string, ConsoleColor>("k", ConsoleColor.DarkGray); }
            else if (blackQueen.Position == position) { return new Tuple<string, ConsoleColor>("q", ConsoleColor.DarkGray); }
            else if (blackBishop1.Position == position || blackBishop2.Position == position) { return new Tuple<string, ConsoleColor>("b", ConsoleColor.DarkGray); }
            else if (blackKnight1.Position == position || blackKnight2.Position == position) { return new Tuple<string, ConsoleColor>("n", ConsoleColor.DarkGray); }
            else if (blackRook1.Position == position || blackRook2.Position == position) { return new Tuple<string, ConsoleColor>("r", ConsoleColor.DarkGray); }
            else { return new Tuple<string, ConsoleColor>(".", ConsoleColor.White); }
        }
    }
}