using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Settings.Interace
{
    public interface IApiSettings
    {
        IGeneralSettings General { get; }
        IDbSettings Db { get; }
        IIdentityServerConnectSettings IdentityServer { get; }
    }
}
