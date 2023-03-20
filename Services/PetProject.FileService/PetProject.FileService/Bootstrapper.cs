using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FileService
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddFileService(this IServiceCollection services)
        {
            services.AddSingleton<IFileService, FileService>();

            return services;
        }
    }
}
