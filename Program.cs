using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe_v1
{
    class Program
    {
        static string[] board = new string[9];
        static string playsAgain = "Y";
        static int counter = 0;

        static void initializeVatiable()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = i.ToString();
            }
        }

        static void playAgainMsg(string message)
        {
            Console.WriteLine(message + " play again ?? ");
            if (Console.ReadLine().Equals("Y"))
                playsAgain.Equals("Y");
            else
                playsAgain.Equals("N");
        }

        static void Main(string[] args)
        {

            introduction();
            while (playsAgain.Equals("Y"))
            {
                initializeVatiable();
                while (hasWon() == false && counter < 9)
                {
                    askData("X");
                    if (hasWon() == true)
                        break;
                    askData("O");
                }
                if (hasWon() == true)
                    playAgainMsg("Hurray ! you Won .");
                else
                    playAgainMsg("The game has TIED !");
            }
        }

        static void askData(string player)
        {
            Console.Clear();

            Console.WriteLine("player: " + player);
            int selection;

            while (true)
            {
                Console.WriteLine("enter your selection \n\n");
                drawboard();
                selection = Convert.ToInt32(Console.ReadLine());
                if (selection < 0 || selection > 8 || board[selection].Equals("X") || board[selection].Equals("O"))
                    Console.WriteLine("invalid selection!");
                else
                    break;
            }
            board[selection] = player;
        }

        static void drawboard()
        {
            Console.WriteLine("____________");
            for (int i = 0; i < 7; i += 3)
            {
                Console.WriteLine(board[i] + " | " + board[i + 1] + " | " + board[i + 2]);
            }
            Console.WriteLine("____________");
        }

        static Boolean hasWon()
        {
            for (int i = 0; i < 7; i += 3)
            {
                if (board[i].Equals(board[i + 1]) && board[i + 1].Equals(board[i + 2]))
                {
                    return false;
                }
            }
            if (board[0].Equals(board[3]) && board[3].Equals(board[6]))
                return true;
            if (board[1].Equals(board[4]) && board[4].Equals(board[7]))
                return true;
            if (board[2].Equals(board[5]) && board[5].Equals(board[8]))
                return true;
            if (board[2].Equals(board[4]) && board[4].Equals(board[6]))
                return true;
            if (board[0].Equals(board[4]) && board[4].Equals(board[8]))
                return true;
            if (board[0].Equals(board[1]) && board[1].Equals(board[2]))
                return true;
            if (board[3].Equals(board[4]) && board[4].Equals(board[5]))
                return true;
            if (board[6].Equals(board[7]) && board[7].Equals(board[8]))
                return true;
            return false;
        }

        static void introduction()
        {
            Console.Title = ("Tic Tac toe Version 1");
            Console.WriteLine("Welcome to Tic Tac Toe,\n\n");
            Console.WriteLine("press Enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
