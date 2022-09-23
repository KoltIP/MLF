using PetProject.Db.Context.Context;
using PetProject.Db.Context.Factories;
using PetProject.Settings.Interace;

namespace PetProject.Worker.Configuration
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IWorkerSettings settings)
        {
            var dbOptionsDelegate = DbContextOptionFactory.Configure(settings.Db.ConnectionString);

            services.AddDbContextFactory<MainDbContext>(dbOptionsDelegate, ServiceLifetime.Singleton);

            return services;
        }

        public static WebApplication UseAppDbContext(this WebApplication app)
        {
            return app;
        }
    }
}
