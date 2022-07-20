using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.TypeServices
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddTypeService(this IServiceCollection services)
        {
            services.AddSingleton<ITypeService, TypeService>();

            return services;
        }

    }
}
