using AutoMapper;
using PetProject.UserAccountService.Models;

namespace PetProject.Api.Controllers.Account.Models
{
    public class UserAccountResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public string Nickname { get; set; }
        public string Email { get; set; }
    }

    public class UserAccountResponseProfile : Profile
    {
        public UserAccountResponseProfile()
        {
            CreateMap<UserModel, UserAccountResponse>();
        }
    }
}
