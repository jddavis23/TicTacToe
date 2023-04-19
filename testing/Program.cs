using System;

class Player
{
    private readonly char x_o;
    public int pos { get; private set; }
    public Player(char symbol)
    {
        x_o = symbol;
    }
    public void movePos()
    {
        Console.WriteLine("Player {0} enter position:", getX_O());
        string inpt = Console.ReadLine()!;
        if (inpt.Length > 1 || inpt[0] < 49 || inpt[0] > 57)
        {
            movePos();
            return;
        }
        pos = inpt[0] - 48;
    }
    public char getX_O()
    {
        return this.x_o;
    }

}

class Board
{
    private int filled = 0;
    static private char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9'};
    static public void printBoard()
    {
        int i = 0;

        //Console.Clear();
        while (i < 9)
        {
            Console.Write(" {0} ", board[i]);
            if ((i + 1) % 3 == 0 && i != 0)
            {
                Console.Write('\n');
                if (i < 6)
                    Console.WriteLine(" -   -   -");
            }
            else
                Console.Write('|');
            ++i;
        }

    }
    private Boolean checkWin(int pos)
    {
        
        int ind = pos - 4;
        int adj = 0;
        char symb = board[pos - 1];

        while (adj < 9)
        {
            Console.WriteLine("pos = {0} ind = {1} adj = {2}", pos, ind, adj);
            if (ind > 0 && ind <= 9 && board[ind] == symb)
            {
                Console.WriteLine("in");
                if (((pos * 2) - ind) < 9 && board[(pos * 2) - ind] == symb)
                {
                    Console.WriteLine("twins");
                    return true;
                }
                else if (((ind + 1) * 2) - pos - 1 < 9 && ((ind + 1) * 2) - pos - 1 >= 0 && board[((ind + 1) * 2) - pos - 1] == symb)
                {
                    Console.WriteLine("{0}", ((ind + 1) * 2) - pos - 1);
                    return true;
                }
            }
            if (adj / 3 == 0)
            {
                Console.WriteLine("AAA");
                ++ind;
            }
            else if (adj / 3 == 1)
            {
                Console.WriteLine("BBB");
                ind = pos - 1;
                if (adj > 3)
                {
                    ind = pos + 1;
                    ++adj;
                }
            }
            else
                ind = (pos + 3) - (adj - 3);
            adj++;
        }
        return false;
    }
    public void makemove(Player a)
    {
        a.movePos();
        while (board[a.pos - 1] < 49 || board[a.pos - 1] > 57)
        {
            Console.Write("Position already taken. ");
            a.movePos();
        }
        board[a.pos - 1] = a.getX_O();
        if (checkWin(a.pos))
        {
            Console.WriteLine("{0} wins.", a.getX_O());
            System.Environment.Exit(0);
        }
        increaseFilled();
    }
    public int getFilled()
    {
        return filled;
    }
    public void increaseFilled()
    {
        ++filled;
    }
}

class Program
{

    private static void Main(string[] args)
    {
        Player one = new('X');
        Player two = new('O');
        Board bd = new();

        while (bd.getFilled() < 9)
        {
            Board.printBoard();
            bd.makemove(one);
            if (bd.getFilled() == 9)
            {
                Console.WriteLine("Tie game.");
                return;
            }
            Board.printBoard();
            bd.makemove(two);
        }
    }
}

