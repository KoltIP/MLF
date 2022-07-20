using PetProject.Db.Entities._Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Db.Entities
{
    public class Advertisement: BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User.User User { get; set; }
        public float Price { get; set; }
        //public Importance Importance { get; set; }
        public Pet Pet { get; set; }
        public int PetId { get; set; }
    }
}
