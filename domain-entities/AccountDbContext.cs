using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain_entities
{
    public class AccountDbContext : DbContext
    {
        public static AccountDbContext ThisInstance;
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            ThisInstance = this;
        }
        public DbSet<Account> Accounts { get; set; }
    }
}
