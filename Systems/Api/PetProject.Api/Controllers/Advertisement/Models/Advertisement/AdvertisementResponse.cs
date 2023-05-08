using AutoMapper;
using PetProject.AdvertisementServices.Models.Advertisement;
using PetProject.Api.Controllers.Advertisement.Models.File;

namespace PetProject.Api.Controllers.Advertisement.Models.Advertisement
{
    public class AdvertisementResponse
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public bool Gender { get; set; }
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
        public List<FileResponse> Images { get; set; }
    }
    public class AdvertismentResponseProfile : Profile
    {
        public AdvertismentResponseProfile()
        {
            CreateMap<AdvertisementModel, AdvertisementResponse>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));
        }
    }
}
