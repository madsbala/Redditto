using System;
using Microsoft.EntityFrameworkCore;

using Redditto.Models;
using Redditto.DataContext;

namespace Redditto.Services
{
    public class DbService
    {
        private BoardContext db { get; }

        public DbService(BoardContext db)
        {
            this.db = db;
        }

        public void SeedData()
        {
            Board board = db.Boards.FirstOrDefault()!;
            if (board == null)
            {
                board = new Board { BoardID = 1, Header = "Regler", Author = "Anonymous"};
                db.Boards.Add(board);
                db.Boards.Add(new Board { BoardID = 2, Header = "Testtråd", Author = "Synonymous"});
            }

            Comment comment = db.Comments.FirstOrDefault()!;
            if (comment == null)
            {
                db.Comments.Add(new Comment { BoardID = 1, Text = "Internettet glemmer ikke", Author = "Anonymous" });
                db.Comments.Add(new Comment { BoardID = 2, Text = "en test kommentar", Author = "Anonymous" });
            }

            db.SaveChanges();

        }

            public List<Board> GetBoards()
            {
                return db.Boards.ToList();
            }
        
            public Board GetBoard(int id)
            {
                return db.Boards.Include(b => b.Comments).FirstOrDefault(b => b.BoardID == id);
            }
/*
            public List<Author> GetAuthors()
            {
                return db.Authors.ToList();
            }

            public Author GetAuthor(int id)
            {
                return db.Authors.Include(a => a.Books).FirstOrDefault(a => a.AuthorId == id);
            }

            public string CreateBoard(string title, int authorId)
            {
                Author author = db.Authors.FirstOrDefault(a => a.AuthorId == authorId);
                db.Books.Add(new Book { Title = title, Author = author });
                db.SaveChanges();
                return "Book created";
            }*/
    }
}

