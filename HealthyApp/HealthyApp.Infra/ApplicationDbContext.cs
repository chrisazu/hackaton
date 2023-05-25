using HealthyApp.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HealthyApp.Infra
{
	public class ApplicationDbContext : IdentityDbContext
	{
		private readonly IConfiguration _config;

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration config)
			: base(options)
		{
			_config = config;
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
				optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
			}
		}
	}
}