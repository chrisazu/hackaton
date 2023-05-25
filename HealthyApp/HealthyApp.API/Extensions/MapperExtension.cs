using HealthyApp.API.Profiles;

namespace HealthyApp.API.Extensions
{
    public static class MapperExtension
    {
        public static void AddMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(HealthyUserProfile));
        }
    }
}
