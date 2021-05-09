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
    class MainClass
    {       
        
        public static string userInput;
        public static Piece cunrrentPiece;
        public static int inputx;
        public static int inputy;
        public static Game game;

        public static bool gameOver { get; set; } = false;


        public static void Main(string[] args)
        {   
            //creates a new game
            game = new Game();



            game.board.updateOneDAryAndList();

            

           /* foreach (Piece p in game.board.game_board) {
                Console.WriteLine(p.Id);
            }
            Console.ReadLine();
            foreach (Piece p  in game.board.boardList) {
                Console.WriteLine(p.Id);
            }*/

            PipeServer pipe = new PipeServer();
            while (!gameOver) {

                pipe.reciveData();
                if (userInput != null) 
                {   
                    SwitchBoard.handelRequest(userInput);
                    userInput = null;
                    pipe.sendData("Hello");
                }
                //await pipe.reciveData();
                //game.board.updateOneDAryAndList();

                Console.WriteLine("the cunrrent piece is: " + cunrrentPiece);
            }

        }

        // this method takes a string which is the piece id in a string format
        // then it selects the piece with the id from the boardList list in game class
        public static void setCurrentPiece(string p) 
        {
            var result = from Piece in game.board.boardList
                         where Piece != null
                         select Piece;

             var result2 = from Piece in result
                          where Piece.Id == p 
                          select Piece;
            List<Piece> tempList = new List<Piece>();

            foreach (Piece i in result2) {
                tempList.Add(i);
            }
            cunrrentPiece = tempList[0];
        }

        

        //gets the position of a piece
        public static string getPiecePosition(Piece p)
        {
            return $"{p.x} {p.y}";
        }

        //gets the cord from pipe and set it to the prop
        public static void setCord(int x, int y)
        {
            inputx = x;
            inputy = y;
        }


    }
}


