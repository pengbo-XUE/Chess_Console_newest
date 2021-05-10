using System;
using System.Collections.Generic;
using System.Text;

namespace Chess2_redo
{
    class Pawn : Piece
    {
        string direction;
        bool firstmove = true;
        Piece[,] temp_b;

        public Pawn(string newName, int one, int two, string clr)
        {
            this.Id = newName;
            this.x = one;
            this.y = two;
            this.color = clr;

            if (firstmove && this.y == 1)
            {
                this.direction = "up";
            }
            else if (firstmove  && this.y == 6) 
            {
                this.direction = "down";
            }
        }
        public override bool check_move(int newx, int newy)
        {   
            
            temp_b = Program.game.board.game_board;
            int abs_v = Math.Abs(newy - this.y);

            if (newx == x && newy > y && direction == "up" && newy > this.y)
            {
                if (abs_v == 2 && firstmove && temp_b[newx, newy] == null && temp_b[x,y+1]== null)
                {
                    
                    firstmove = false;
                    return true;
                }
                else if (abs_v == 1 && temp_b[newx, newy] == null) 
                {
                    if (firstmove) firstmove = false;
                    return true;
                }
                return false;
            }
            else if (newx == x && newy < y && direction == "down" && newy < this.y)
            {
                if (abs_v == 2 && firstmove == true && temp_b[newx, newy] == null && temp_b[x, y - 1] == null)
                {
                    firstmove = false;
                    return true;
                }
                else if (abs_v == 1 && temp_b[newx, newy] == null)
                {
                    return true;
                }
                return false;
            }

            // these codes are for checking if pawn is caping a enemy piece
            // might need to make this shorter in the future
            //SE
            else if (newx == x + 1 && newy == y - 1 && direction == "down") 
            {
                return pawnCheckCap(newx, newy);
            }
            //SW
            else if (newx == x - 1 && newy ==  y-1 && direction == "down") 
            {
                return pawnCheckCap(newx, newy);
            }
            //NE
            else if (newx == x + 1 && newy == y + 1 && direction == "up") 
            {
                return pawnCheckCap(newx, newy);
            }
            //NW
            else if (newx == x - 1 && newy == y + 1 && direction == "up") 
            {
                return pawnCheckCap(newx, newy);
            }
            return false;

        }

        public bool pawnCheckCap(int newx, int newy) 
        {
            if (temp_b[newx, newy] != null && temp_b[newx, newy].color != this.color)
            {
                Program.game.deletePiece(temp_b[newx, newy].color, temp_b[newx, newy].Id);
                return true;
            }
            return false;
        }
    }
}
