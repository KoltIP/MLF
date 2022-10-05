using AutoMapper;
using PetProject.AdvertisementServices.Models;

namespace PetProject.Api.Controllers.Advertisement.Models
{
    public class AdvertisementResponse
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public float Price { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; } = string.Empty;
        public string PetDescription { get; set; } = string.Empty;
        public string PetColor { get; set; } = string.Empty;
        public string PetBreed { get; set; } = string.Empty;
        public string PetType { get; set; } = string.Empty;
    }
    public class AdvertismentResponseProfile : Profile
    {
        public AdvertismentResponseProfile()
        {
            CreateMap<AdvertisementModel, AdvertisementResponse>();
        }
    }
}
