using HealthyApp.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthyApp.Infra
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<User> HealthyUsers { get; set; }

		public DbSet<Goal> Goals { get; set; }

		public DbSet<Reward> Rewards { get; set; }
	}
}