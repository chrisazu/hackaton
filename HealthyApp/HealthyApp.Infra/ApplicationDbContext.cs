using HealthyApp.Domain.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HealthyApp.Infra
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IConfiguration _config;

        public ApplicationDbContext()
        {
            //_config = config;
        }

        public DbSet<User> HealthyUsers { get; set; }

        public DbSet<Goal> Goals { get; set; }

        public DbSet<Reward> Rewards { get; set; }

        public DbSet<Level> Levels { get; set; }

        public DbSet<Progress> Progresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HealthyAppDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Level>().HasData(
                new Level() { Id = 1, Name = "Beginner", Description = "Beginner" },
                new Level() { Id = 2, Name = "Intermediate", Number = 2, Description = "Intermediate" },
                new Level() { Id = 3, Name = "Upper Intermediate", Number = 3, Description = "Upper Intermediate" },
                new Level() { Id = 4, Name = "Advanced", Number = 4, Description = "Advanced" }
            );
        }
        
    }
}