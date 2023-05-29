using HealthyApp.Domain.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthyApp.Infra
{
	public class ApplicationDbContext : IdentityDbContext
	{
		//private readonly IConfiguration _config;

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
				new Level() { Id = 1, Name = "Beginner", Description = "Estoy como Leonardo DiCaprio" },
				new Level() { Id = 2, Name = "Intermediate", Number = 2, Description = "Estoy como Emma Stone" },
				new Level() { Id = 3, Name = "Upper Intermediate", Number = 3, Description = "Estoy como Chris Pratt" },
				new Level() { Id = 4, Name = "Advanced", Number = 4, Description = "Estoy como Scarlett Johansson" },
				new Level() { Id = 5, Name = "Skilled", Number = 5, Description = "Estoy como Dwayne Johnson" },
				new Level() { Id = 6, Name = "Expert", Number = 6, Description = "Estoy como Angelina Jolie" },
				new Level() { Id = 7, Name = "Elite", Number = 7, Description = "Estoy como Tom Hardy" },
				new Level() { Id = 8, Name = "Grandmaster", Number = 8, Description = "Estoy como Gal Gadot" },
				new Level() { Id = 9, Name = "Masterful", Number = 8, Description = "Estoy como Chris Hemsworth" },
				new Level() { Id = 10, Name = "Champion", Number = 8, Description = "Estoy como Arnold Schwarzenegger" }
			);
		}
	}
}