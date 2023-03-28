using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FileService.Models
{
    public class FileResponseModel
    {
        public int Id { get; set; }
        public string ImageDataUrl { get; set; }
        public long Size { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
