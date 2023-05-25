using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           
        }
    }
}
