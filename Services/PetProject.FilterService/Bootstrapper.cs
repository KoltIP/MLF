using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FilterService
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddFilterService(this IServiceCollection services)
        {
            services.AddSingleton<IFilterService, FilterService>();

            return services;
        }

    }
}
