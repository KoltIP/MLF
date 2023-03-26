using PetProject.Db.Entities._Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Db.Entities
{
    public class City : BaseEntity
    {
        [Index(IsUnique = true)]
        public string Name { get; set; } = String.Empty;
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
