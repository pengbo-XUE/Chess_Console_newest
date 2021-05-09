using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2_redo
{
    class Rook : Piece
    {
        
        public Rook(string newName, int one, int two)
        {
            this.Id = newName;
            this.x = one;
            this.y = two;
        }
        public override bool check_move(int newx, int newy)
        {
            Piece[,] temp_b = MainClass.game.board.game_board;

            /*foreach (var i in temp_b)
            {
                Console.WriteLine("in loop: "+ i);
            }*/

            if (newx == this.x)
            {
                int v = Math.Abs(newy - this.y);
               // Console.WriteLine("abs value: " + v);
                if (newy > this.y)
                {
                    for (int i = 1; i <= v; i++)
                    {
                        //Console.WriteLine("in the check if loop " + newy);
                       // Console.WriteLine("in the check if loop seacond " + temp_b[0,3]);
                        //Console.WriteLine("in the check if loop third " + v);
                        if (temp_b[this.x, this.y + i] != null)
                        {   
                            //Console.WriteLine("two " + i);
                            return false;
                        }
                       
                    }
                    return true;
                }
                //this is when the new pos is on the left of the original position
                else if (newy < this.y)
                {
                    for (int i = 1; i < v; i++)
                    {
                        if (temp_b[this.x, this.y - i] != null)
                        {
                            //Console.WriteLine(i);
                            return false;
                        }
                       
                    }
                    return true;
                }

            }



            else if (newy == this.y)
            {
                //getting the abs value of difference between the new value and the old
                int v = Math.Abs(newx - this.x);
                //Console.WriteLine("abs value: "+v);
                //when new pos is on the right of the original position
                if (newx > this.x)
                {
                    for (int i = 1; i < v; i++)
                    {
                        if (temp_b[this.x + i, this.y] != null)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                //this is when the new pos is on the left of the original position
                else if (newx < this.x)
                {
                    for (int i = 1; i < v; i++)
                    {
                        if (temp_b[this.x - i, this.y] != null)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            // if the new pos is the same as the original move is invalid
            else if (newy == this.y && newx == this.x)
            {
                return false;
            }

            return false;
        }
    }


}

