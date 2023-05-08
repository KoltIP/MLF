using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.AdvertisementServices.Models.File
{
    public class AddFileModel
    {
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
