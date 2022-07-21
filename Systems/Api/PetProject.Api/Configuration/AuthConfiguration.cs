using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PetProject.Db.Context.Context;
using PetProject.Db.Entities;
using PetProject.Db.Entities.User;
using PetProject.Settings.Interace;
using PetProject.Shared.Common.Security;
using System.IdentityModel.Tokens.Jwt;

namespace PetProject.Api.Configuration
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAppAuth(this IServiceCollection services, IApiSettings settings)
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

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.RequireHttpsMetadata = settings.IdentityServer.RequireHttps;
                    options.Authority = settings.IdentityServer.Url;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = false,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                    options.Audience = "api";
                });


            services.AddAuthorization(options =>
            {
                options.AddPolicy(AppScopes.PetRead, policy => policy.RequireClaim("scope", AppScopes.PetRead));
                options.AddPolicy(AppScopes.PetWrite, policy => policy.RequireClaim("scope", AppScopes.PetWrite));
            });

            return services;
        }

        public static IApplicationBuilder UseAppAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseAuthorization();

            return app;
        }
    }
}
