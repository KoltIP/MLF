using PetProject.Settings;
using Microsoft.Extensions.DependencyInjection;
using PetProject.ColorServices;
using PetProject.BreedServices;
using PetProject.TypeServices;
using PetProject.AdvertisementServices;
using PetProject.UserAccountService;
using PetProject.EmailService;
using PetProject.RabbitMqService;
using PetProject.CommentServices;
using PetProject.FileService;
using PetProject.LocationService;
using PetProject.FavoutiteService;
using PetProject.SubscribeService;
using PetProject.FilterService;

namespace PetProject.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddSettings();
            services.AddColorService();
            services.AddBreedService();
            services.AddTypeService();
            services.AddAdvertisementService();
            services.AddUserAccountService();
            services.AddEmailSender();
            services.AddRabbitMq();
            services.AddCommentService();
            services.AddFileService();
            services.AddLocationService();
            services.AddFavouriteService();
            services.AddSubscribeService();
            services.AddFilterService();

            return services;
        }
        
    }
}
