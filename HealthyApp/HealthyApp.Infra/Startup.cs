using HealthyApp.Domain.Interfaces;
using HealthyApp.Infra.Repository;

using Microsoft.Extensions.DependencyInjection;

namespace HealthyApp.Infra
{
	public class Startup
    {
        public static void Load(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IHealthyUserRepository, HealthyUserRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
			services.AddScoped<IGoalRepository, GoalRepository>();
		}
    }
}
