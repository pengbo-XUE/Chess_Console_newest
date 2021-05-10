using System;
using System.Collections.Generic;
using System.Text;

namespace Chess2_redo
{
    class Bishop : Piece
    {
        public Bishop(string newName, int one, int two, string clr)
        {
            this.Id = newName;
            this.x = one;
            this.y = two;
            this.color = clr;
        }
        public override bool check_move(int newx, int newy)
        {
            Piece[,] temp_b = Program.game.board.game_board;
            int abs_v_y = Math.Abs(newy - this.y);
            int abs_v_x = Math.Abs(newx - this.x);

            if (newx > x && newy > x) { }
            else if (newx > x && newy < y) { }
            else if (newx < x && newy > y) { }
            else if (newx < x && newy < y) { }
            else if (newx == x && newy == y) return false;
            return false;

        }
    }
}