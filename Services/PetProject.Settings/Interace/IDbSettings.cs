using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Settings.Interace
{
    public interface IDbSettings
    {
        string ConnectionString { get; }
    }
}
