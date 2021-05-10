using System;
using System.Collections.Generic;
using System.Text;

namespace Chess2_redo
{
    class Pawn : Piece
    {
        string direction;
        bool firstmove = true;
        public Pawn(string newName, int one, int two, string clr)
        {
            this.Id = newName;
            this.x = one;
            this.y = two;
            this.color = clr;

            if (firstmove == true && this.y == 1)
            {
                this.direction = "up";
            }
            else if (firstmove == true && this.y == 6) 
            {
                this.direction = "down";
            }
        }
        public override bool check_move(int newx, int newy)
        {   
            
            Piece[,] temp_b = MainClass.game.board.game_board;


            if (newx > x && newy > x) { }
            else if (newx > x && newy < y) { }
            else if (newx < x && newy > y) { }
            else if (newx < x && newy < y) { }
            else if (newx == x && newy == y) return false;
            return false;

        }
    }
}
