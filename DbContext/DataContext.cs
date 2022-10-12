using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Redditto.Models;

namespace Redditto.DataContext
{
    public class BoardContext : DbContext
    {
        public DbSet<Board> Boards => Set<Board>();
        public DbSet<Comment> Comments => Set<Comment>();

        public BoardContext(DbContextOptions<BoardContext> options)
            : base(options)
        {
            // I am empty :3
        }
    }
}

