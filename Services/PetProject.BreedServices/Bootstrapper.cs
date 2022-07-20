using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.BreedServices
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBreedService(this IServiceCollection services)
        {
            services.AddSingleton<IBreedService, BreedService>();

            return services;
        }
    }
}
