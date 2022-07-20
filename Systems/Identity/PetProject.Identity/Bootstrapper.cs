using PetProject.Settings;

namespace PetProject.Identity
{
    public static class Bootstrapper
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddSettings();

        }
    }
}
