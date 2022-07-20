
using AutoMapper;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.PetServices.Models
{
    public class PetModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ColorId { get; set; }
        public string Color { get; set; } = string.Empty;
        public int TypeId { get; set; }
        public string Type { get; set; } = string.Empty;
       
    }

    public class PetModelProfile : Profile
    {
        public PetModelProfile()
        {
            CreateMap<Pet, PetModel>()
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.PetTypeId));
        }
    }
}
