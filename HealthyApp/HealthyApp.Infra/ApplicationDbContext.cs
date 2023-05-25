using HealthyApp.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HealthyApp.Infra
{
	public class ApplicationDbContext : IdentityDbContext
	{
		private readonly IConfiguration _config;

		public ApplicationDbContext(/*IConfiguration config*/)
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
	}
}