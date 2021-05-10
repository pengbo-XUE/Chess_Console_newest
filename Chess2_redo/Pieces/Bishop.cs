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

            //moving NE
            if (newx > x && newy > y) 
            {
                for (int i = 1; i <= abs_v_x; i++) 
                {
                    if (temp_b[x + i, y + i] != null) 
                    {
                        if (this.x + i == newx && this.y + i == newy &&
                               temp_b[this.x+i, this.y + i].color != this.color)
                        {
                            Program.game.deletePiece(temp_b[this.x+i, this.y + i].color, temp_b[this.x+i, this.y + i].Id);
                            return true;
                        }
                        return false;
                    }
                    
                }
                return true;
            }

            //moving SE
            else if (newx > x && newy < y) 
            {
                for (int i = 1; i <= abs_v_x; i++)
                {
                    if (temp_b[x + i, y - i] != null)
                    {
                        if (this.x + i == newx && this.y - i == newy &&
                               temp_b[this.x +i, this.y - i].color != this.color)
                        {
                            Program.game.deletePiece(temp_b[this.x + i, this.y - i].color, temp_b[this.x + i, this.y - i].Id);
                            return true;
                        }
                        return false;
                    }

                }
                return true;
            }

            //moving NW
            else if (newx < x && newy > y) 
            {
                for (int i = 1; i <= abs_v_x; i++)
                {
                    if (temp_b[x - i, y + i] != null)
                    {
                        if (this.x - i == newx && this.y + i == newy &&
                               temp_b[this.x - i, this.y + i].color != this.color)
                        {
                            Program.game.deletePiece(temp_b[this.x - i, this.y + i].color, temp_b[this.x - i, this.y + i].Id);
                            return true;
                        }
                        return false;
                    }

                }
                return true;
            }

            //moving SW
            else if (newx < x && newy < y) 
            {
                for (int i = 1; i <= abs_v_x; i++)
                {
                    if (temp_b[x - i, y - i] != null)
                    {
                        if (this.x - i == newx && this.y - i == newy &&
                               temp_b[this.x - i, this.y - i].color != this.color)
                        {
                            Program.game.deletePiece(temp_b[this.x - i, this.y - i].color, temp_b[this.x - i, this.y - i].Id);
                            return true;
                        }
                        return false;
                    }

                }
                return true;
            }
            else if (newx == x && newy == y) return false;
            return false;

        }
    }
}