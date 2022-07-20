using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PetProject.Db.Context.Context;
using PetProject.Db.Entities;
using PetProject.Db.Entities.User;
using PetProject.Identity.Configuration.IS4;

namespace PetProject.Identity.Configuration
{
    public static class IS4Configuration
    {
        public static IServiceCollection AddIS4(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole<Guid>>(opt =>
                {
                    opt.Password.RequiredLength = 0;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<MainDbContext>()
                .AddUserManager<UserManager<User>>()
                .AddDefaultTokenProviders();

            services
                .AddIdentityServer()
                .AddAspNetIdentity<User>()
                .AddInMemoryApiScopes(AppApiScopes.ApiScopes)
                .AddInMemoryClients(AppClients.Clients)
                .AddInMemoryApiResources(AppResources.Resources)
                .AddInMemoryIdentityResources(AppIdentityResources.Resources)
                .AddDeveloperSigningCredential();
            //.AddTestUsers(AppApiTestUsers.ApiUsers);



            return services;
        }

        public static IApplicationBuilder UseIS4(this IApplicationBuilder app)
        {
            app.UseIdentityServer();

            return app;
        }
    }
}
