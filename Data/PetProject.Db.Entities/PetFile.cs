using PetProject.Db.Entities._Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Db.Entities
{
    public class PetFile : BaseEntity
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string ImageDataUrl { get; set; }
        public string ContentType { get; set; }        
        public string Content { get; set; }
    }
}
