using ChatService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChatService.Data
{
    public class ApplicationDbContext : DbContext
    {
            public DbSet<User> Users  { get; set; }
            public DbSet<Message> Messages { get; set; }

    }
}