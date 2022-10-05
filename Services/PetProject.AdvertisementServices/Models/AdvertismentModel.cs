using AutoMapper;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.AdvertisementServices.Models
{
    public class AdvertisementModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; } = string.Empty;
        public string PetDescription { get; set; } = string.Empty;
        public float Price { get; set; }        
        public string PetColor { get; set; } = string.Empty;
        public string PetBreed { get; set; } = string.Empty;
        public string PetType { get; set; } = string.Empty;

    }

    public class AdvertisementModelProfile : Profile
    {
        public AdvertisementModelProfile()
        {
            CreateMap<Advertisement, AdvertisementModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name))
                .ForMember(dest => dest.PetDescription, opt => opt.MapFrom(src => src.Pet.Description))
                .ForMember(dest => dest.PetId, opt => opt.MapFrom(src => src.PetId))
                .ForMember(dest => dest.PetColor, opt => opt.MapFrom(src => src.Pet.Color.Name))
                .ForMember(dest => dest.PetBreed, opt => opt.MapFrom(src => src.Pet.Breed.Name))
                .ForMember(dest => dest.PetType, opt => opt.MapFrom(src => src.Pet.Type.Name));
        }
    }
}
