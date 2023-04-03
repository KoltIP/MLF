using AutoMapper;
using PetProject.AdvertisementServices.Models;

namespace PetProject.Api.Controllers.Advertisement.Models
{
    public class AdvertisementResponse
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsWanted { get; set; }
        public string? PetName { get; set; } = string.Empty;
        public string? PetDescription { get; set; } = string.Empty;
        public float? Price { get; set; }
        public int PetColorId { get; set; }
        public int PetTypeId { get; set; }
        public int PetBreedId { get; set; }
        public int CityId { get; set; }        
        public string PetColor { get; set; } = string.Empty;
        public string PetBreed { get; set; } = string.Empty;
        public string PetType { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int? Age { get; set; }
        public DateTime? DateLost { get; set; }
        public int ImageId { get; set; }
        public byte[] ImageContent { get; set; }
        public string ImageContentType { get; set; } = string.Empty;
    }
    public class AdvertismentResponseProfile : Profile
    {
        public AdvertismentResponseProfile()
        {
            CreateMap<AdvertisementModel, AdvertisementResponse>();
                 //.ForMember(dest => dest.IsWanted, opt => opt.MapFrom(src => (src.IsWanted == true ? "Разыскивается" : "Найдено")));
        }
    }
}
