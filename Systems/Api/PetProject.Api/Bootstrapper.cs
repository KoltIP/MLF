using PetProject.PetServices;
using PetProject.Settings;
using Microsoft.Extensions.DependencyInjection;
using PetProject.ColorServices;
using PetProject.BreedServices;
using PetProject.TypeServices;
using PetProject.AdvertisementServices;
using PetProject.UserAccountService;

namespace PetProject.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddSettings();
            services.AddPetService();
            services.AddColorService();
            services.AddBreedService();
            services.AddTypeService();
            services.AddAdvertisementService();
            services.AddUserAccountService();            
            return services;
        }
        
    }
}
