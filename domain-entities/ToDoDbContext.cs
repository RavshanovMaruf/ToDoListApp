using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain_entities
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public ToDoDbContext()
        {
        }

        public DbSet<ToDoList> ToDoList { get; set; }
    }
}
