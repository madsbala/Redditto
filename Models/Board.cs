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
        public int BoardID { get; set; }
        public string Header { get; set; }
        public string? Author { get; set; }
        public List<Comment> Comments { get; set; }

        /*[Required]
        public int BoardID { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime TimePosted { get; set; }

        [Required]
        public int Upvote { get; set; }

        [Required]
        public int Downvote { get; set; }*/
    }
}
