using Microsoft.AspNetCore.Identity;
using PetProject.Db.Entities._Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Db.Entities.User
{
    public class User : IdentityUser<Guid>
    {
        public string NickName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Patronymic { get; set; }
        public int Age { get; set; }
        public string? Specialization { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
        public UserStatus Status { get; set; }
    }
}
