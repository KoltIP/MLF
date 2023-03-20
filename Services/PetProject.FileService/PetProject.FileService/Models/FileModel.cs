using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FileService.Models
{
    public class FileModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String ContentType { get; set; }
        public Int64 Size { get; set; }
        public Byte[] Content { get; set; }
        public String ImageDataUrl { get; set; }

        public FileModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
