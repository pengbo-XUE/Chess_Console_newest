﻿using Microsoft;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Chess2_redo
{
    class Game
    {
        public int GameId { get; set; }
        //public List<Player> players { get; set; }

        [ForeignKey("BoardIdId")]
        public Board board { get; set; }
        public Player whiteSide;
        public Player blackSide;
        public Rook br1;
        public Rook br2;
        public Rook wr1;
        
        public Game()
        {
            //players declared
            blackSide = new Player("black");
            whiteSide = new Player("white");
            //board declared
            board = new Board();

            //pieces declared
            br1 = new Rook("br1", 0, 0,"b");
            br2 = new Rook("br2", 1, 0,"b");
            wr1 = new Rook("wr1", 0, 2, "w");

            //hard coded adding piece to player list
            blackSide.onBoard.Add(this.br1);
            blackSide.onBoard.Add(this.br2);
            whiteSide.onBoard.Add(this.wr1);


            //pos assignment
            this.board.game_board[0, 0] = this.br1;
            this.board.game_board[1, 0] = this.br2;
            this.board.game_board[0, 2] = this.wr1;
            board.updateOneDAryAndList();
        }

        public void deletePiece(string p)
        {
            var result = from Piece in board.boardList
                         where Piece != null
                         select Piece;
            var result2 = result.Single(r => r.Id == p);
            board.boardList.Remove(result2);
        }

        public  void deletePiece(string player, string p)
        {
            if (player == "b")
            {
                var result = from Piece in blackSide.onBoard
                             where Piece != null
                             select Piece;
                var result2 = result.Single(r => r.Id == p);
                blackSide.onBoard.Remove(result2);
            }
            else if (player == "w")
            {
                var result = from Piece in whiteSide.onBoard
                             where Piece != null
                             select Piece;
                var result2 = result.Single(r => r.Id == p);
                whiteSide.onBoard.Remove(result2);
            }

            var result0 = from Piece in board.boardList
                         where Piece != null
                         select Piece;
            var result3 = result0.Single(r => r.Id == p);
            board.boardList.Remove(result3);
        }
    }

    class BoardDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        //public DbSet<Player> Players { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Piece> Pieces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-BC5EN6M\SQLEXPRESS;Initial Catalog=Chess_Db1;Integrated Security=True");
        }
        
    }
}