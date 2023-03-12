using PetProject.Db.Entities._Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Db.Entities
{
    public class Breed : BaseEntity
    {
        [Index(IsUnique = true)]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public virtual ICollection<PetType> PetTypes { get; set; }
    }
}
