using Microsoft.EntityFrameworkCore;
using PetProject.Db.Context.Context;
using PetProject.Db.Context.Factories;
using PetProject.Db.Context.Setup;
using PetProject.Settings.Interace;

namespace PetProject.Api.Configuration
{
    public static class DbConfiguration
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IApiSettings settings)
        {
            var dbOptionsDelegate = DbContextOptionFactory.Configure(settings.Db.ConnectionString);
            services.AddDbContextFactory<MainDbContext>(dbOptionsDelegate, ServiceLifetime.Singleton);
            return services;
        }

        public static IApplicationBuilder UseAppDbContext(this IApplicationBuilder app)
        {
            DbInit.Execute(app.ApplicationServices);

            DbSeed.Execute(app.ApplicationServices);

            return app;
        }
    }
}
