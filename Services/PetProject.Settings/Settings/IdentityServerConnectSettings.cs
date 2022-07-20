using PetProject.Settings.Interace;
using PetProject.Settings.Sourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Settings.Settings
{
    public class IdentityServerConnectSettings : IIdentityServerConnectSettings
    {
        private readonly ISettingsSource source;
        public IdentityServerConnectSettings(ISettingsSource source) => this.source = source;

        public string Url => source.GetAsString("IdentityServer:Url");
        public string ClientId => source.GetAsString("IdentityServer:ClientId");
        public string ClientSecret => source.GetAsString("IdentityServer:ClientSecret");
        public bool RequireHttps => Url.ToLower().StartsWith("https://");
    }
}
