using PetProject.Db.Entities._Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Db.Entities
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ColorId { get; set; }
        public int PetTypeId { get; set; }
        public virtual PetType Type { get; set; }
        public virtual Color Color { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
