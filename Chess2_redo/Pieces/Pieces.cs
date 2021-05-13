using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2_redo
{
    public class Piece
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string color { get; set; }
        //reverse
        public int? previousX;
        public int? previousY;

        public virtual bool move(int newx, int newy) 
        {
            
            if (this.checkMove(newx, newy))
            {   
                //Console.WriteLine("in the if loop"+ newx+" "+newy);
                Program.game.board.game_board[x, y] = null;
                Program.game.board.game_board[newx, newy] = this;

                this.previousX = x;
                this.previousY = y;
                this.x = newx;
                this.y = newy;

                Console.WriteLine("valid");
                //Program.pipe.sendData("p_move_valid");
                Program.game.board.updateOneDAryAndList();
                return true;
                

            }
            Console.WriteLine("invalid");
            //Program.pipe.sendData("p_move_invalid");
            return false;
        }
        public virtual bool checkMove(int i, int j) { return false; }
        
        
    }
}
