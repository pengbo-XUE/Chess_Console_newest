using System;
using System.Collections.Generic;
using System.Text;

namespace Chess2_redo
{
    class King : Piece
    {
        public List<int[]> avaliableMoves;
       
        public King(string newName, int one, int two, string clr)
        {
            this.Id = newName;
            this.x = one;
            this.y = two;
            this.color = clr;
            avaliableMoves = new List<int[]>();
       
        }
        
        public override bool checkMove(int newx, int newy) 
        {
            this.updateKingList();
          
            foreach (int[] ary in avaliableMoves) 
            {
                if (ary[0] == newx && ary[1] == newy) return true;
            }
            return false;
        }

        public void updateKingList()
        {
            int[][] moves = new int[][]
            {
            new int[] { x, y + 1 },
            new int[] { x, y - 1 }, 
            new int[] { x + 1, y + 1 }, 
            new int[] { x - 1, y - 1 },
            new int[] { x - 1, y + 1 },
            new int[] { x + 1, y - 1 },
            new int[] { x - 1, y },
            new int[] { x + 1, y }
            };
            Player enemy = new Player("temp");
            King enemyKing = new King("temp", 0, 0, "none");
            if (this.color == "b")
            {
                enemy = Program.game.whiteSide;
                enemyKing = Program.game.wkk;
            }
            
            else if (this.color == "w") 
            { 
                enemy = Program.game.blackSide;
                enemyKing = Program.game.bkk;
            } 

            //king checking each other causing stack over flow;
            foreach (int[] ary in moves) 
            {
                //Console.WriteLine("before the loop:     " + ary[0]+",  "+ary[1]);
                if (ary[0] >= 0 && ary[1] >= 0 && ary[0] <= 7 && ary[1] <= 7) 
                {
                    bool valid = true;
                    foreach (Piece p in enemy.onBoard)
                    {

                        if (p.Id != "bkk" && p.Id != "wkk")
                        {
                            //here is the problem
                            if (p.checkMove(ary[0], ary[1])) valid = false;
                        }
                        else if (p.Id == "bkk" || p.Id == "wkk")
                        {
                            foreach (int[] enemeyAry in enemyKing.avaliableMoves)
                            {
                                if (enemeyAry == ary) valid = false;
                            }
                        }
                    }
                    //Console.WriteLine("this is the board :     " + Program.game.board.game_board[ary[0], ary[1]].Id);
                    if ((valid&& Program.game.board.game_board[ary[0], ary[1]] == null) 
                        || (valid && Program.game.board.game_board[ary[0], ary[1]].color != this.color)) 
                        avaliableMoves.Add(ary);
                }
            }
        }
    }
}
//&& (Program.game.board.game_board[ary[0],ary[1]] == null|| Program.game.board.game_board[ary[0], ary[1]].color != this.color)

//why is update king list not working in the constructor??
//why cant i update king list in the game constructor??

// IMPORTANT: TIM!!! THE SPACE != NULL IS NOT IMPLEMENTED!!!!!!