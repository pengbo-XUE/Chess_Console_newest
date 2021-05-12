using System;
using System.Collections.Generic;
using System.Text;

namespace Chess2_redo
{
    class Queen : Piece
    {
        public Queen(string newName, int one, int two, string clr)
        {
            this.Id = newName;
            this.x = one;
            this.y = two;
            this.color = clr;
        }
        public override bool checkMove(int newx, int newy)
        {
            Piece[,] temp_b = Program.game.board.game_board;
            int abs_v_x = Math.Abs(newx - this.x);
            //GOING STRIGHT
            if (newx == this.x)
            {
                int abs_v = Math.Abs(newy - this.y);
                if (newy > this.y)
                {
                    for (int i = 1; i <= abs_v; i++)
                    {

                        if (temp_b[this.x, this.y + i] != null)
                        {
                            //this if loop determines if the last place the piece lands on has a enemy on it
                            //delets the enemy piece and replaces it in the position
                            if (this.x == newx && this.y + i == newy &&
                                temp_b[this.x, this.y + i].color != this.color)
                            {
                                return true;
                            }
                            return false;
                        }

                    }
                    return true;
                }
                //this is when the new pos is on the left of the original position
                else if (newy < this.y)
                {
                    for (int i = 1; i <= abs_v; i++)
                    {
                        if (temp_b[this.x, this.y - i] != null)
                        {
                            //this if loop determines if the last place the piece lands on has a enemy on it
                            //delets the enemy piece and replaces it in the position
                            if (this.x == newx && this.y - i == newy &&
                                temp_b[this.x, this.y - i].color != this.color)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                    return true;
                }

            }



            else if (newy == this.y)
            {
                //getting the abs value of difference between the new value and the old
                int abs_v = Math.Abs(newx - this.x);

                //when new pos is on the right of the original position
                if (newx > this.x)
                {
                    for (int i = 1; i <= abs_v; i++)
                    {

                        if (temp_b[this.x + i, this.y] != null)
                        {
                            //this if loop determines if the last place the piece lands on has a enemy on it
                            //delets the enemy piece and replaces it in the position
                            if (this.x + i == newx && this.y == newy &&
                                temp_b[this.x + i, this.y].color != this.color)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                    return true;
                }
                //this is when the new pos is on the left of the original position
                else if (newx < this.x)
                {
                    for (int i = 1; i <= abs_v; i++)
                    {
                        if (temp_b[this.x - i, this.y] != null)
                        {
                            //this if loop determines if the last place the piece lands on has a enemy on it
                            //delets the enemy piece and replaces it in the position
                            if (this.x - i == newx && this.y == newy &&
                                temp_b[this.x - i, this.y].color != this.color)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                    return true;
                }
            }

            //GOING DIAGONAL


            //moving NE
            else if (newx > x && newy > y)
            {
                for (int i = 1; i <= abs_v_x; i++)
                {
                    if (temp_b[x + i, y + i] != null)
                    {
                        if (this.x + i == newx && this.y + i == newy &&
                               temp_b[this.x + i, this.y + i].color != this.color)
                        {

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
                               temp_b[this.x + i, this.y - i].color != this.color)
                        {

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
                            return true;
                        }
                        return false;
                    }

                }
                return true;
            }

            // if the new pos is the same as the original move is invalid
            else if (newy == this.y && newx == this.x) return false;


            return false;
        }
    }
}
