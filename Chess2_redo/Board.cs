using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Chess2_redo
{
    class Board
    {
        public int BoardId { get; set; }
        public Piece[,] game_board = new Piece[8, 8];
        public Piece[] boardJson = new Piece[64];
        public List<Piece> boardList { get; set; }
        public string boardJsonString;
        //inits the boardJson
        public Board()
        {
            updateOneDAryAndList();

        }

        public Piece[,] getBorad()
        {
            return this.game_board;
        }

        public List<Piece> BoardtoList(Piece[,] board)
        {
            List<Piece> list = new List<Piece>();
            foreach (Piece i in board)
            {
                if(i!=null)list.Add(i);
            }
            return list;
        }

        //method for turning 2d ary into to a 1d array
        public Piece[] oneDBoard(Piece[,] board)
        {
            List<Piece> ary = new List<Piece>();
            foreach (Piece i in board)
            {
                ary.Add(i);
            }

            return ary.ToArray();
        }

        //updates one D array
        public void updateOneDAryAndList()
        {
            boardJson = this.oneDBoard(this.game_board);
            boardJsonString = JsonSerializer.Serialize(this.boardJson);
            boardList = BoardtoList(this.game_board);
        }

        //test writing the result to a txt file
     /*   public void writeToTxt()
        {
            string filePath = @"C:\Users\Pengbo Xue\Documents\output.txt"; ;
            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                outputFile.WriteLine(boardJsonString);
            }
        }*/

        // gets a board from DB
        public string getBoardFromDb(int id)
        {
            var context = new BoardDbContext();
            string temp = context.Boards.Where(c => c.BoardId == id).ToString();
            return temp;
        }
    }
}
