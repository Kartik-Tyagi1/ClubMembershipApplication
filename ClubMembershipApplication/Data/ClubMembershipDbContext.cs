using System;
using System.Collections.Generic;
using System.Text;
using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubMembershipApplication.Data
{
    public class ClubMembershipDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure connection string and pass to base class method
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}ClubMembershipDb.db");
            base.OnConfiguring(optionsBuilder);
        }

        // Table DB Structure based on the User Model
        public DbSet<User> Users { get; set; }
    }
}
