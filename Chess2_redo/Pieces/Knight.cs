using System;
using System.Collections.Generic;
using System.Text;

namespace Chess2_redo
{
    class Knight : Piece
    {
        Piece[,] temp_b;
        public Knight(string newName, int one, int two, string clr)
        {
            this.Id = newName;
            this.x = one;
            this.y = two;
            this.color = clr;
        }
        public override bool checkMove(int newx, int newy)
        {
            temp_b = Program.game.board.game_board;
            int abs_v_y = Math.Abs(newy - this.y);
            int abs_v_x = Math.Abs(newx - this.x);
            
            if ((abs_v_x == 1 && abs_v_y == 2)|| (abs_v_x == 2 && abs_v_y == 1)) 
            {
                if(temp_b[newx,newy] != null)
                {
                    if (temp_b[newx, newy].color != this.color)
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}