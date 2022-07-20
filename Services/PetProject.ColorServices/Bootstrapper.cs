using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.ColorServices
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddColorService(this IServiceCollection services)
        {
            services.AddSingleton<IColorService, ColorService>();

            return services;
        }

    }
}
