using HealthyApp.Profiles;

namespace HealthyApp.Extensions
{
    public static class MapperExtension
    {
        public static void AddMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(HealthyUserProfile));
        }
    }
}
