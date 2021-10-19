using HomeApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HomeApp.Db
{
    public class HomeAppContext : DbContext
    {
        public DbSet<HomeAppUser> Users { get; set; }

        public HomeAppContext(DbContextOptions<HomeAppContext> options) : base(options)
        {
            _ = Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<HomeAppUser>().HasData(new List<HomeAppUser>
            {
                new HomeAppUser
                {
                    Id = 1,
                    FirstName = "Johnny",
                    LastName = "Depp",
                    Username = "jdepp",
                    JobTitle = "Erin's BFF",
                    Company = "Self-Employed",
                    About = "I am an actor and more importantly Erin's BFF"
                },
                new HomeAppUser
                {
                    Id = 2,
                    FirstName = "Erin",
                    LastName = "McLaughlin",
                    Username = "emclaughlin",
                    JobTitle = "Software Engineer",
                    Company = "Nunya",
                    About = "I like coding."
                }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
