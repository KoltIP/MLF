using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FileService.Models
{
    public class AddFileModel
    {
        public String ContentType { get; set; }
        public Byte[] Content { get; set; }
    }
}
