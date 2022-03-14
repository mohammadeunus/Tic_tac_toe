using System;

class Program{
    static char[,] board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
    char token = 'X';

    //not null two string 
    string? n1  , n2;
    int row, column;
    static bool tie=false;


    // Main method
    static void Main(string[] args)
    {
        Program p = new Program();
        //how the board will look like
        p.Board();

        //take in the name of each player
        Console.Write("enter the name of the first player: ");
        p.n1 = Console.ReadLine();
        Console.Write("enter the name of the second player: ");
        p.n2 = Console.ReadLine();

        Console.Write("{0} is player1 so he/she will play first \n",p.n1);
        Console.Write("{0} is player2 so he/she will play second \n",p.n2);

        Console.WriteLine(p.checkBoard());
        while (!p.checkBoard())
        {
            p.Board();
            p.makeMove();
            p.checkBoard();
        }


        if (p.token == 'X' && tie == false)
        {
            Console.WriteLine("{0} Wins!!", p.n2);
        }
        else if (p.token == '0' && tie == false)
        {
            Console.WriteLine("{0} Wins!!", p.n1);
        }
        else
        {
            Console.WriteLine("its a draw!!");
        }

    }


    void makeMove()
    {
        int digit = 0;


        if (token == 'X')
        {
            Console.Write("please enter: ");
            digit = Convert.ToInt32(Console.ReadLine());
        }
        if (token == '0')
        {
            Console.Write("please enter: ");
            digit = Convert.ToInt32(Console.ReadLine());
        }

        //assigning the X or 0 on the board
        if (digit >= 1 && digit <= 3){
            row = 0; 
            column = digit-1;
        }

        else if (digit >= 4 && digit <= 6){
            row = 1;
            column = digit-4;
        }
        else if (digit >= 7 && digit <= 9){
            row = 2;
            column = digit-7;
        }
        else
        {
            Console.WriteLine("Invalid input, please make sure you insert 1-9 value!!!");
        }



        if (token == 'X' && board[row, column] != 'X' && board[row, column] != '0')
        {
            board[row, column] = 'X';
            token = '0';
        }
        else if (token == '0' && board[row, column] != 'X' && board[row, column] != '0')
        {
            board[row, column] = '0';
            token = 'X';
        }
        else
        {
            Console.WriteLine("There is no empty space!");
            makeMove();
        }
        Board();
    }

    bool checkBoard(){
        for (int i = 0; i < 3; i++){
            if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] || board[0, i] == board[1, i] && board[0, i] == board[2, i]){
                return true;
            }
        }    

        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] || board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            return true;
        }
        

        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                if (board[i, j] != 'X' && board[i, j] != '0'){
                    return false;
                }
            }
        }

        tie = true;
        return false;
    }


    //the board how will it look like
    void Board(){
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[0, 0], board[0, 1], board[0, 2]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[1, 0], board[1, 1], board[1, 2]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[2, 0], board[2, 1], board[2, 2]);
        Console.WriteLine("     |     |      ");
    }


}

