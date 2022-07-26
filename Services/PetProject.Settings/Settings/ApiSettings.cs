﻿using PetProject.Settings.Interace;
using PetProject.Settings.Sourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Settings.Settings
{
    public class ApiSettings : IApiSettings
    {
        private readonly ISettingsSource source;
        private readonly IIdentityServerConnectSettings identityServerSettings;
        private readonly IGeneralSettings generalSettings;
        private readonly IDbSettings dbSettings;

        public ApiSettings(ISettingsSource source) => this.source = source;

        public ApiSettings(ISettingsSource source, IIdentityServerConnectSettings identityServerSettings, IGeneralSettings generalSettings, IDbSettings dbSettings)
        {
            this.source = source;
            this.identityServerSettings = identityServerSettings;
            this.generalSettings = generalSettings;
            this.dbSettings = dbSettings;
        }

        public IIdentityServerConnectSettings IdentityServer => identityServerSettings ?? new IdentityServerConnectSettings(source);

        public IGeneralSettings General => generalSettings ?? new GeneralSettings(source);

        public IDbSettings Db => dbSettings ?? new DbSettings(source);
    }
}
