using PetProject.Db.Context.Context;
using PetProject.Db.Context.Factories;
using PetProject.Settings.Interace;

namespace PetProject.Identity.Configuration
{
    public static class DbConfiguration
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IDbSettings settings)
        {
            var dbOptionsDelegate = DbContextOptionFactory.Configure(settings.ConnectionString);

            services.AddDbContextFactory<MainDbContext>(dbOptionsDelegate, ServiceLifetime.Singleton);

            return services;
        }

        public static IApplicationBuilder UseAppDbContext(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
