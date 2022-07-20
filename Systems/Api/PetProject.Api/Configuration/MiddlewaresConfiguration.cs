using PetProject.Api.Middleware;

namespace PetProject.Api.Configuration
{
    public static class MiddlewaresConfiguration
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionsMiddleware>();
        }
    }
}
