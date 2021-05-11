using System;
using System.Collections.Generic;
using System.Text;

namespace Chess2_redo
{
    static class CheckMate
    {
        //check self first

        //if check self fails move fails

        //check enemy

        public static bool cheackCheck(Player p) 
        {
            Piece king = new King("temp", 0,0,"none");
            Player enemy = new Player("temp");
            foreach (Piece piece in p.onBoard) 
            {
                if (piece.Id == "bkk" || piece.Id == "wkk") 
                {
                    king = piece;
                }
            }
            foreach (Player player in Program.game.players)
            {
                if (player != p)
                {
                    enemy = player;
                }
            }

            foreach (Piece piece1 in enemy.onBoard) 
            {
                if (piece1.checkMove(king.x, king.y)) 
                {
                    p.check = true;
                    return true;
                }
            }
            return false;
        }

        public static bool checkCheckMate(Player p,King king) 
        {
            Program.game.bkk.updateKingList();
            Program.game.wkk.updateKingList();
            if (cheackCheck(p) && king.avaliableMoves == null) 
            {
                return true;
            }

            return false;
        }
    }
}
