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
                    Program.game.cunrrentPlayer.getKing().updateKingList();
                    if (Program.game.previousPlayer != null 
                        && Program.game.cunrrentPiece.color == Program.game.previousPlayer.color) 
                    {
                        Program.appendReturn("n_moved");
                        Program.appendReturn("same_color");
                        break;
                    }
                    //taking out the delete piece method from checkMove so that the king can use it
                    if (Program.game.board.game_board[Program.game.inputx, Program.game.inputy] != null
                        && Program.game.cunrrentPiece.checkMove(Program.game.inputx, Program.game.inputy) ) 
                    {
                        //Program.appendReturn("delete,"+ Program.game.board.game_board[Program.game.inputx, Program.game.inputy].Id);
                        Program.game.deletePiece(Program.game.board.game_board[Program.game.inputx, Program.game.inputy].color,
                        Program.game.board.game_board[Program.game.inputx, Program.game.inputy].Id);
                        
                    }
                    

                    //check the condition of check or check mate after the piece has been moved
                    if (Program.game.cunrrentPiece.move(Program.game.inputx, Program.game.inputy)) 
                    {
                        if (Program.game.previousPlayer != null
                                && CheckMate.cheackCheck(Program.game.previousPlayer)) 
                        {
                            Program.game.previousPlayer.check = true;
                        }
                        if (Program.game.previousPlayer != null 
                                && CheckMate.checkCheckMate(Program.game.previousPlayer, Program.game.previousPlayer.getKing()))
                        {
                            
                            Program.gameOver = true;
                            Program.appendReturn("game_over");
                        }
                        Program.game.setPreviousPlayer();
                        Program.appendReturn("moved");
                        
                        break;
                    }
                    Program.appendReturn("n_moved");
                    Program.appendReturn("invalid");
                    break;

                case "reset":
                    Program.game = new Game();
                    Console.WriteLine("Board reset");
                    Program.appendReturn("game_reset");
                    break;

                case "gameover":
                    Program.gameOver = true;
                    Program.appendReturn("game_over");
                    break;

            }
        }
    }
}
