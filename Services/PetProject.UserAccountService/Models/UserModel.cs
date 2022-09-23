using AutoMapper;
using PetProject.Db.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.UserAccountService.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Surname, o => o.MapFrom(s => s.Surname))
                .ForMember(d => d.Patronymic, o => o.MapFrom(s => s.Patronymic))
                .ForMember(d => d.Nickname, o => o.MapFrom(s => s.NickName))                
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email));
        }
    }
}
