using Microsoft;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chess2_redo
{
    class Game
    {
        public int GameId { get; set; }
        //public List<Player> players { get; set; }

        [ForeignKey("BoardIdId")]
        public Board board { get; set; }
        public Rook br1;
        public Rook br2;
        public Game()
        {
            //players declared
            Player blackSide = new Player("black");
            Player whiteSide = new Player("white");
           // players.Add(blackSide);
            //players.Add(whiteSide);
            board = new Board();

            //hard coded declearing pieces
            br1 = new Rook("br1", 0, 0);
            br2 = new Rook("br2", 0, 0);
            //board.updateOneDAryAndList();

            //hard coded adding piece to player list
            blackSide.onBoard.Add(this.br1);

            //hard code pos assignment DELETE LATER
            this.board.game_board[0, 0] = this.br1;
            this.board.game_board[0, 3] = this.br2;
            //int[] ary = board.game_board[0];
            board.updateOneDAryAndList();
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