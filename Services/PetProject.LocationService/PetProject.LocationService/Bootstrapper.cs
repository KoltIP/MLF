using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.LocationService
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddLocationService(this IServiceCollection services)
        {
            services.AddSingleton<ILocationService, LocationService>();

            return services;
        }

    }
}
