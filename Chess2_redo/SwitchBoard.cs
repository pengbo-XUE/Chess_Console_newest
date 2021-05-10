using System;
using System.Collections.Generic;
using System.Text;

namespace Chess2_redo
{
    public static class SwitchBoard
    {
        public static void handelRequest(string request)
        { 
            switch (request)
            {
                case "move":
                    Console.WriteLine("From switch board"+MainClass.game.cunrrentPiece);
                    MainClass.game.cunrrentPiece.move(MainClass.game.inputx, MainClass.game.inputy);
                    if (CheckWin.check())
                    {
                        MainClass.gameOver = true;
                        MainClass.pipe.sendData("game_over");
                    }
                    //Console.WriteLine("Piece moved");
                    break;
                case "reset":
                    MainClass.game = new Game();
                    Console.WriteLine("Board reset");
                    MainClass.pipe.sendData("game_reset");
                    break;
            }
        }
    }
}
