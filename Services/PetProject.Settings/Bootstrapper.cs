﻿using Microsoft.Extensions.DependencyInjection;
using PetProject.Settings.Interace;
using PetProject.Settings.Settings;
using PetProject.Settings.Sourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Settings
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddSettings(this IServiceCollection services)
        {
            services.AddSingleton<ISettingsSource, SettingsSource>();
            services.AddSingleton<IApiSettings, ApiSettings>();
            services.AddSingleton<IIS4Settings, IS4Settings>();
            services.AddSingleton<IIdentityServerConnectSettings, IdentityServerConnectSettings>();
            services.AddSingleton<IGeneralSettings, GeneralSettings>();
            services.AddSingleton<IDbSettings, DbSettings>();
            services.AddSingleton<IEmailSettings, EmailSettings>();
            services.AddSingleton<IRabbitMqSettings, RabbitMqSettings>();
            services.AddSingleton<IWorkerSettings, WorkerSettings>();

            return services;
        }
    }
}
