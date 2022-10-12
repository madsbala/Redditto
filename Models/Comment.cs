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
        public int CommentID { get; set; }
        public int BoardID { get; set; }
        public string Text { get; set; }
        public string? Author { get; set; }
        //public int Votes { get; set; }
        //public DateTime Timestamp { get; set; }

        public Comment()
        {
        }
    }
}
