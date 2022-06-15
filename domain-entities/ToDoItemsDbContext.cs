using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain_entities
{
    public class ToDoItemsDbContext : DbContext
    {
        public ToDoItemsDbContext(DbContextOptions<ToDoItemsDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ToDoItems> ToDoItem { get; set; }
    }
}
