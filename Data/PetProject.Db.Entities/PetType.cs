using PetProject.Db.Entities._Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Db.Entities
{
    public class PetType : BaseEntity
    {
        [Index(IsUnique = true)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
