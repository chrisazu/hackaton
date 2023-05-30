using HealthyApp.Domain.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthyApp.Infra
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
            // ToDo: inject config
            //_config = config;
        }

        public DbSet<User> HealthyUsers { get; set; }

        public DbSet<Reward> Rewards { get; set; }

        public DbSet<Level> Levels { get; set; }

        public DbSet<Goal> Goals { get; set; }

        public DbSet<ExerciseGoal> ExerciseGoals { get; set; }

        public DbSet<DietGoal> DietGoals { get; set; }

        public DbSet<Progress> Progresses { get; set; }

        public DbSet<ExerciseProgress> ExerciseProgresses { get; set; }

        public DbSet<DietProgress> DietProgresses { get; set; }

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

            modelBuilder.Entity<DietGoal>().ToTable("DietGoals");

            modelBuilder.Entity<ExerciseGoal>().ToTable("ExercisesGoals");

            modelBuilder.Entity<DietProgress>().ToTable("DietProgresses");

            modelBuilder.Entity<ExerciseProgress>().ToTable("ExerciseProgresses");

            modelBuilder.Entity<Level>().HasData(
                new Level() { Id = 1, Name = "Beginner", Number = 1, Description = "Estás como Leonardo DiCaprio", Url = "https://m.media-amazon.com/images/M/MV5BMjI0MTg3MzI0M15BMl5BanBnXkFtZTcwMzQyODU2Mw@@.jpg" },
                new Level() { Id = 2, Name = "Intermediate", Number = 2, Description = "Estás como Emma Stone", Url = "https://m.media-amazon.com/images/M/MV5BMjI4NjM1NDkyN15BMl5BanBnXkFtZTgwODgyNTY1MjE@.jpg" },
                new Level() { Id = 3, Name = "Upper Intermediate", Number = 3, Description = "Estás como Chris Pratt" , Url = "https://m.media-amazon.com/images/M/MV5BZjdkYjg1NzMtOTY2YS00ZWI1LWEwZWYtOTU1YTM2ODA2ZWY5XkEyXkFqcGdeQXVyMTM1MjAxMDc3.jpg" },
                new Level() { Id = 4, Name = "Advanced", Number = 4, Description = "Estás como Scarlett Johansson", Url = "https://m.media-amazon.com/images/M/MV5BMTM3OTUwMDYwNl5BMl5BanBnXkFtZTcwNTUyNzc3Nw@@.jpg" },
                new Level() { Id = 5, Name = "Skilled", Number = 5, Description = "Estás como Dwayne Johnson", Url  = "https://m.media-amazon.com/images/M/MV5BMTkyNDQ3NzAxM15BMl5BanBnXkFtZTgwODIwMTQ0NTE@.jpg" },
                new Level() { Id = 6, Name = "Expert", Number = 6, Description = "Estás como Angelina Jolie", Url = "https://m.media-amazon.com/images/M/MV5BODg3MzYwMjE4N15BMl5BanBnXkFtZTcwMjU5NzAzNw@@.jpg" },
                new Level() { Id = 7, Name = "Elite", Number = 7, Description = "Estás como Tom Hardy", Url = "https://m.media-amazon.com/images/M/MV5BMTQ3ODEyNjA4Nl5BMl5BanBnXkFtZTgwMTE4ODMyMjE@.jpg" },
                new Level() { Id = 8, Name = "Grandmaster", Number = 8, Description = "Estás como Gal Gadot", Url = "https://m.media-amazon.com/images/M/MV5BNzgxYTA2OTUtYmE0ZC00ZTc0LWJjY2QtOTIzMTJhNGUyZjBlXkEyXkFqcGdeQXVyMTg4NDI0NDM@.jpg" },
                new Level() { Id = 9, Name = "Masterful", Number = 9, Description = "Estás como Chris Hemsworth", Url = "https://m.media-amazon.com/images/M/MV5BOTU2MTI0NTIyNV5BMl5BanBnXkFtZTcwMTA4Nzc3OA@@.jpg" },
                new Level() { Id = 10, Name = "Champion", Number = 10, Description = "Estás como Arnold Schwarzenegger", Url = "https://m.media-amazon.com/images/M/MV5BMTI3MDc4NzUyMV5BMl5BanBnXkFtZTcwMTQyMTc5MQ@@.jpg" }
            );

            modelBuilder.Entity<Reward>().HasData(
                new Reward() { Id = 1, Name = "Beginner", Description = "tenés descuento en tiendas D1" },
                new Reward() { Id = 2, Name = "Intermediate", Description = "tenés descuento en tiendas Ara" },
                new Reward() { Id = 3, Name = "Upper Intermediate", Description = "tenés descuento en tiendas Éxito" },
                new Reward() { Id = 4, Name = "Advanced", Description = "tenés descuento en tiendas Olympica" },
                new Reward() { Id = 5, Name = "Skilled", Description = "tenés descuento en tiendas Carulla" },
                new Reward() { Id = 6, Name = "Expert", Description = "tenés descuento en tiendas Jumbo" },
                new Reward() { Id = 7, Name = "Elite", Description = "tenés descuento en tiendas Metro" },
                new Reward() { Id = 8, Name = "Grandmaster", Description = "tenés descuento en tiendas SmartFit" },
                new Reward() { Id = 9, Name = "Masterful", Description = "tenés descuento en tiendas Adidas" },
                new Reward() { Id = 10, Name = "Champion", Description = "tenés descuento en tiendas Decathlon" }
            );
        }
    }
}