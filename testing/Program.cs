
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

        Console.Clear();
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
    public void makemove(Player a)
    {
        a.movePos();
        while (board[a.pos - 1] < 49 || board[a.pos - 1] > 57)
        {
            Console.Write("Position already taken. ");
            a.movePos();
        }
        board[a.pos - 1] = a.getX_O();
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
            Board.printBoard();
            bd.makemove(two);
        }
    }
}

