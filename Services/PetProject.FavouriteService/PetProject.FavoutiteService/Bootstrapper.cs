using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FavoutiteService
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddFavouriteService(this IServiceCollection services)
        {
            services.AddSingleton<IFavouriteService, FavouriteService>();

            return services;
        }

    }
}
