using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Chess2_redo
{
    //program will recive a string which is turned into an array 
    //array[0] is the command
    //array[1] is the x cord
    //array[2] is the y cord
    //array [3] is the piece that is to be moved
    class Program
    {
        public static Game game;
        public static PipeServer pipe;
        public static bool gameOver { get; set; } = false;
        public static string returnStr;

        public static void Main(string[] args)
        {

            //creates a new game

            game = new Game();
            game.board.updateOneDAryAndList();
            pipe = new PipeServer();

            //game.bkk.updateKingList();
            while (!gameOver)
            {

                pipe.reciveData();
                if (game.userInput != null)
                {
                    SwitchBoard.handelRequest(game.userInput);
                    Program.pipe.sendData(returnStr);
                    game.userInput = null;
                }

                game.board.updateOneDAryAndList();
                game.wkk.updateKingList();
                game.bkk.updateKingList();
                clearReturn();
            }

        }

        public static void appendReturn(string str)
        {
            if (returnStr == null) returnStr = str.Trim();

            else returnStr = returnStr + "," + str.Trim();
            Console.WriteLine(returnStr);
        }

        public static void clearReturn()
        {
            returnStr = null;
        }
    }
}


