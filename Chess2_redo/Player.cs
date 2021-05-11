using System;
using System.Collections.Generic;
using System.Text;

namespace Chess2_redo
{
    class Player
    {
        public string color { get; set; }
        public List<Piece> onBoard { get; set; }

        public bool check = false;

        public Player(string side)
        {   
            onBoard = new List<Piece>();
            color = side;
        }

        public King getKing()
        {
            if (this.color == "b") return Program.game.bkk;
            else if (this.color == "w") return Program.game.wkk;
            return null;
        }
    }
}
