using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redditto.Models;

namespace Redditto.Models
{
    public class Board
    {
        public Board(int boardID, string header, string author, List<Comment> comments, int vote, DateTime timePosted)
        {
            this.BoardID = boardID;
            this.Header = header;
            this.Author = author;
            this.Comments = comments;
            this.Vote = vote;
            this.TimePosted = timePosted;
        }

        public int BoardID { get; set; }
        public string Header { get; set; }
        public string? Author { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public int Vote { get; set; }
        public DateTime TimePosted { get; set; }

        public Board()
        {
            BoardID = 0;
            Header = "";
            Author = "";
            Vote = 0;
            TimePosted = DateTime.Now;
        }

        public override string ToString()
        {
            return $"BoardID: {BoardID}, Header: {Header}, Author {Author}, Votes: {Vote}, Time Posted: {TimePosted}";
        }
    }
}
