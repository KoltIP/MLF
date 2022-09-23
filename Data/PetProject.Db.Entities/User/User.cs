using Microsoft.AspNetCore.Identity;

namespace PetProject.Db.Entities.User
{
    public class User : IdentityUser<Guid>
    {
        public string NickName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Patronymic { get; set; }
        public int Age { get; set; }
        public string? Specialization { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
        public UserStatus Status { get; set; }
    }
}
