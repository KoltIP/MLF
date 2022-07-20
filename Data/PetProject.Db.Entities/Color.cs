using PetProject.Db.Entities._Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Db.Entities
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
