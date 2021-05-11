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
                    //taking out the delete piece method from checkMove so that the king can use it
                    if (Program.game.board.game_board[Program.game.inputx, Program.game.inputy] != null
                        && Program.game.cunrrentPiece.checkMove(Program.game.inputx, Program.game.inputy) ) 
                    {
                        Console.WriteLine("please dont come here");
                        Program.game.deletePiece(Program.game.board.game_board[Program.game.inputx, Program.game.inputy].color,
                        Program.game.board.game_board[Program.game.inputx, Program.game.inputy].Id);
                        
                    }

                    Program.game.cunrrentPiece.move(Program.game.inputx, Program.game.inputy);

                    if (CheckMate.checkCheckMate(Program.game.cunrrentPlayer, Program.game.cunrrentPlayer.getKing()))
                    {
                        Program.gameOver = true;
                        Program.pipe.sendData("game_over");
                    }
                    Program.game.setCurrentPlayer();

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
