using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HealthyApp.Application
{
	public class Startup
	{
		public static void Load(IServiceCollection services)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());
		}
	}
}
