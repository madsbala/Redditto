using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;

using Redditto.Models;
using Redditto.DataContext;

namespace Redditto.Services
{
    public class DbService
    {
        private BoardContext db { get; }

        private readonly HttpClient http;

        public DbService(BoardContext db)
        {
            this.db = db;
        }

        //Vores Seed-data

        public void SeedData() 
        {
            Board board = db.Boards.FirstOrDefault()!;
            if (board == null)
            {
                board = new Board { BoardID = 1, Header = "Regler", Author = "Anonymous" };
                db.Boards.Add(board);
                db.Boards.Add(new Board { BoardID = 2, Header = "Testtråd", Author = "Synonymous", Vote = 5, TimePosted = DateTime.Now });
                db.Boards.Add(new Board { BoardID = 3, Header = "Endnu en test", Author = "Antonymous", Vote = 1, TimePosted = DateTime.Now });
                db.Boards.Add(new Board { BoardID = 4, Header = "Hvad lavver du stadig her", Author = "Mr Troll", Vote = 5000, TimePosted = DateTime.Now });
            }

            Comment comment = db.Comments.FirstOrDefault()!;
            if (comment == null)
            {
                db.Comments.Add(new Comment { BoardID = 1, Text = "Internettet glemmer ikke", Author = "Anonymous", Vote = -11, Timestamp = DateTime.Now });
                db.Comments.Add(new Comment { BoardID = 2, Text = "en test kommentar", Author = "Anonymous", Vote = 2, Timestamp = DateTime.Now });
                db.Comments.Add(new Comment { BoardID = 1, Text = "så der kan ikke slettes", Author = "Anonymous", Vote = 5, Timestamp = DateTime.Now });
                db.Comments.Add(new Comment { BoardID = 1, Text = "No shit Sherlock", Author = "Mr Troll", Vote = 420, Timestamp = DateTime.Now });
            }

            db.SaveChanges();

        }

        //Henter alle boards og sætter dem på en liste

        public List<Board> GetBoards()
        {
            return db.Boards.ToList();
        }

        //Henter alle comments og sætter dem på en liste (bruges ikke)

        public List<Comment> GetComments()
        {
            return db.Comments.ToList();
        }

        //Henter comments til et specifikt board og sætter dem på en liste

        public List<Comment> GetBoardComments(int id)
        {
            return db.Comments.Where(b => b.BoardID == id).ToList();
        }

        //Henter specifikt board

        public Board GetBoard(int id)
        {
            return db.Boards.FirstOrDefault(b => b.BoardID == id);
        }

        //Opretter et nyt board - hvis author er tom sættes den til at være 'Anonymous'

        public string CreateBoard(string header, string author, DateTime timePosted )
        {
            if (author == "") {author = "Anonymous";};
            db.Boards.Add(new Board { Header = header, Author = author, TimePosted = timePosted = DateTime.Now });
            db.SaveChanges();
            return "Board created";
        }

        //Opretter en ny comment- hvis author er tom sættes den til at være 'Anonymous'

        public string CreateComment(int boardId, string text, string author, DateTime timestamp )
        {
            if (author == "") {author = "Anonymous";};
            db.Comments.Add(new Comment { BoardID = boardId, Text = text, Author = author, Timestamp = timestamp = DateTime.Now });
            db.SaveChanges();
            return "Comment created";
        }

        //Kan upvote board

        public string UpvoteBoard(int id) 
        {    
         var votes = db.Boards.Where(b => b.BoardID == id).FirstOrDefault();
            votes.Vote = votes.Vote + 1;
         db.SaveChanges();
         return "Board upvoted";
        }

        //Kan downvote board

        public string DownvoteBoard(int id) 
        {
            var votes = db.Boards.Where(b => b.BoardID == id).FirstOrDefault();
            votes.Vote = votes.Vote - 1;
            db.SaveChanges();
            return "Board downvoted";
        }

        //Kan upvote comment

        public string UpvoteComment(int id) 
        {
            var votes = db.Comments.Where(b => b.CommentID == id).FirstOrDefault();
            votes.Vote = votes.Vote + 1;
            db.SaveChanges();
            return "Comment upvoted";
        }

        //Kan downvote comment

        public string DownvoteComment(int id) 
        {
            var votes = db.Comments.Where(b => b.CommentID == id).FirstOrDefault();
            votes.Vote = votes.Vote - 1;
            db.SaveChanges();
            return "Comment downvoted";
        }
    }
}

