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
        public string PetName { get; set; } = string.Empty;
        public string PetDescription { get; set; } = String.Empty;
        public int PetColorId { get; set; }
        public int PetBreedId { get; set; }
        public int PetTypeId { get; set; }
        public virtual PetType Type { get; set; }
        public virtual Color Color { get; set; }
        public virtual Breed Breed { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }

        //public Importance Importance { get; set; }
        //public DateTime Age { get; set; }
        //public DateTime CreatedDate { get; set; } = DateTime.Now.Date;
    }
}
