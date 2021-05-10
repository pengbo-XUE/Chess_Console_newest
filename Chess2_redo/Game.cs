using Microsoft;
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


        //MICS stuff
        [ForeignKey("BoardIdId")]
        public Board board { get; set; }
        public string userInput;
        public Piece cunrrentPiece;
        public int inputx;
        public int inputy;

        //players declared
        public Player whiteSide;
        public Player blackSide;

        public Rook br1, br2, wr1, wr2;
        public Bishop bb1, bb2, wb1, wb2;
        public Pawn bp1, bp2, bp3, bp4, bp5, bp6, bp7, bp8;
        public Pawn wp1, wp2, wp3, wp4, wp5, wp6, wp7, wp8;
        public Game()
        {
            //players declared
            blackSide = new Player("black");
            whiteSide = new Player("white");
            //board declared
            board = new Board();

            //pieces declared

            //ROOKS
            br1 = new Rook("br1", 0, 0,"b");
            br2 = new Rook("br2", 7, 0,"b");
            wr1 = new Rook("wr1", 0, 7, "w");
            wr2 = new Rook("wr2", 7, 7, "w");

            //BISHOPS
            bb1 = new Bishop("bb1", 1, 0, "b");
            bb2 = new Bishop("bb2", 6, 0, "b");
            wb1 = new Bishop("wb1", 1, 7, "w");
            wb2 = new Bishop("wb2", 6, 7, "w");

            //BLACK PAWNS
            bp1 = new Pawn("bp1", 0, 1, "b");
            bp2 = new Pawn("bp2", 1, 1, "b");
            bp3 = new Pawn("bp3", 2, 1, "b");
            bp4 = new Pawn("bp4", 3, 1, "b");
            bp5 = new Pawn("bp5", 4, 1, "b");
            bp6 = new Pawn("bp6", 5, 1, "b");
            bp7 = new Pawn("bp7", 6, 1, "b");
            bp8 = new Pawn("bp8", 7, 1, "b");

            //WHITE PAWNS
            wp1 = new Pawn("wp1", 0, 6, "w");
            wp2 = new Pawn("wp2", 1, 6, "w");
            wp3 = new Pawn("wp3", 2, 6, "w");
            wp4 = new Pawn("wp4", 3, 6, "w");
            wp5 = new Pawn("wp5", 4, 6, "w");
            wp6 = new Pawn("wp6", 5, 6, "w");
            wp7 = new Pawn("wp7", 6, 6, "w");
            wp8 = new Pawn("wp8", 7, 6, "w");

            //adding piece to player list
            //ROOKS
            blackSide.onBoard.Add(this.br1);
            blackSide.onBoard.Add(this.br2);
            whiteSide.onBoard.Add(this.wr1);
            whiteSide.onBoard.Add(this.wr2);

            //BISHOPS
            blackSide.onBoard.Add(this.bb1);
            blackSide.onBoard.Add(this.bb2);
            whiteSide.onBoard.Add(this.wb1);
            whiteSide.onBoard.Add(this.wb2);

            //BLACK PAWNS
            blackSide.onBoard.Add(this.bp1);
            blackSide.onBoard.Add(this.bp2);
            blackSide.onBoard.Add(this.bp3);
            blackSide.onBoard.Add(this.bp4);
            blackSide.onBoard.Add(this.bp5);
            blackSide.onBoard.Add(this.bp6);
            blackSide.onBoard.Add(this.bp7);
            blackSide.onBoard.Add(this.bp8);

            //WHITE PAWNS
            whiteSide.onBoard.Add(this.wp1);
            whiteSide.onBoard.Add(this.wp2);
            whiteSide.onBoard.Add(this.wp3);
            whiteSide.onBoard.Add(this.wp4);
            whiteSide.onBoard.Add(this.wp5);
            whiteSide.onBoard.Add(this.wp6);
            whiteSide.onBoard.Add(this.wp7);
            whiteSide.onBoard.Add(this.wp8);
           

            //pos assignment
            //ROOKS
            this.board.game_board[0, 0] = this.br1;
            this.board.game_board[7, 0] = this.br2;
            this.board.game_board[0, 7] = this.wr1;
            this.board.game_board[7, 7] = this.wr2;

            //BISHOPS
            this.board.game_board[1, 0] = this.bb1;
            this.board.game_board[6, 0] = this.bb2;
            this.board.game_board[1, 7] = this.wb1;
            this.board.game_board[6, 7] = this.wb2;

            //BLACK PAWN
            this.board.game_board[0, 1] = this.bp1;
            this.board.game_board[1, 1] = this.bp2;
            this.board.game_board[2, 1] = this.bp3;
            this.board.game_board[3, 1] = this.bp4;
            this.board.game_board[4, 1] = this.bp5;
            this.board.game_board[5, 1] = this.bp6;
            this.board.game_board[6, 1] = this.bp7;
            this.board.game_board[7, 1] = this.bp8;
            //WHITE PAWN
            this.board.game_board[0, 6] = this.wp1;
            this.board.game_board[1, 6] = this.wp2;
            this.board.game_board[2, 6] = this.wp3;
            this.board.game_board[3, 6] = this.wp4;
            this.board.game_board[4, 6] = this.wp5;
            this.board.game_board[5, 6] = this.wp6;
            this.board.game_board[6, 6] = this.wp7;
            this.board.game_board[7, 6] = this.wp8;

            board.updateOneDAryAndList();
        }
        //these two methods deletes the given piece from a list/lists
        public void deletePiece(string p)
        {
            var result = from Piece in board.boardList
                         where Piece != null
                         select Piece;
            var result2 = result.Single(r => r.Id == p);
            board.boardList.Remove(result2);
        }
       
        public void deletePiece(string player, string p)
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

        // this method takes a string which is the piece id in a string format
        // then it selects the piece with the id from the boardList list in game class
        public void setCurrentPiece(string p)
        {
            var result = from Piece in board.boardList
                         where Piece != null
                         select Piece;

            var result2 = from Piece in result
                          where Piece.Id == p
                          select Piece;
            List<Piece> tempList = new List<Piece>();

            foreach (Piece i in result2)
            {
                tempList.Add(i);
            }
            cunrrentPiece = tempList[0];
        }

        //gets the position of a piece
        public static string getPiecePosition(Piece p)
        {
            return $"{p.x} {p.y}";
        }

        //gets the cord from pipe and set it to the prop
        public void setCord(int x, int y)
        {
            inputx = x;
            inputy = y;
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