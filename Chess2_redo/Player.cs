using System;
using System.Collections.Generic;
using System.Text;

namespace Chess2_redo
{
    class Player
    {
        public string color { get; set; }
        public List<Piece> onBoard { get; set; }
        public Player(string side)
        {   
            onBoard = new List<Piece>();
            color = side;
        }
        
    }
}
