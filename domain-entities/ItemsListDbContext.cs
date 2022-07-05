using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain_entities
{
    public class ItemsListDbContext : DbContext
    {
        public static ItemsListDbContext ThisInstance;

        public DbSet<ToDoList> Lists { get; set; }
        public DbSet<ToDoItems> Items { get; set; }
        public DbSet<ItemsList> ItemsLists { get; set; }

        public ItemsListDbContext(DbContextOptions<ItemsListDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            ThisInstance = this;
        }
    }
}
