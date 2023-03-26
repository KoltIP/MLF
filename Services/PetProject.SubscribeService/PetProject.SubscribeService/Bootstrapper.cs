using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.SubscribeService
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddSubscribeService(this IServiceCollection services)
        {
            services.AddSingleton<ISubscribeService, SubscribeService>();

            return services;
        }

    }
}
