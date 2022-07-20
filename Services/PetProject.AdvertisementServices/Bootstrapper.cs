using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.AdvertisementServices
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAdvertisementService(this IServiceCollection services)
        {
            services.AddSingleton<IAdvertisementService, AdvertisementService>();

            return services;
        }

    }
}
