using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FileService.Models
{
    public class FileResponseModel
    {
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
