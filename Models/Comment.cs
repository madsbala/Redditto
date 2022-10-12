using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redditto.Models
{
    public class Comment
    {
        public Comment()
        {
        }

        public Comment(int commentID, int boardID, string text, string author, int vote, DateTime timestamp)
        {
            this.CommentID = commentID;
            this.BoardID = boardID;
            this.Text = text;
            this.Author = author;
            this.Vote = vote;
            this.Timestamp = timestamp;
        }

        public int CommentID { get; set; }
        public int BoardID { get; set; }
        public string Text { get; set; }
        public string? Author { get; set; }
        public int Vote { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
