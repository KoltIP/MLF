using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.PetServices
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddPetService(this IServiceCollection services)
        {
            services.AddSingleton<IPetService, PetService>();

            return services;
        }

    }
}
