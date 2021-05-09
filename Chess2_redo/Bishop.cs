using System;
using System.Collections.Generic;
using System.Text;

namespace Chess2_redo
{
    class Bishop : Piece
    {
        public Bishop(string newName, int one, int two)
        {
            this.Id = newName;
            this.x = one;
            this.y = two;
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