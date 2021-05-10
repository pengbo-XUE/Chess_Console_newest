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
                    Console.WriteLine("From switch board"+Program.game.cunrrentPiece);
                    Program.game.cunrrentPiece.move(Program.game.inputx, Program.game.inputy);
                    if (CheckWin.check())
                    {
                        Program.gameOver = true;
                        Program.pipe.sendData("game_over");
                    }
                    //Console.WriteLine("Piece moved");
                    break;
                case "reset":
                    Program.game = new Game();
                    Console.WriteLine("Board reset");
                    Program.pipe.sendData("game_reset");
                    break;

                case "gameover":
                    Program.gameOver = true;
                    Program.pipe.sendData("game_over");
                    break;

            }
        }
    }
}
