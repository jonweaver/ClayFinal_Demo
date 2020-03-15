using GroupDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace GroupDemo.Data
{
    public class ApplicationContext :DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Change this to match the name of your local SQL instance
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-28CTE90;Initial Catalog=GroupDB; Integrated Security = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany("GroupMembers");

            modelBuilder.Entity<GroupMember>()
                .HasMany("Groups");
        }
    }
}
