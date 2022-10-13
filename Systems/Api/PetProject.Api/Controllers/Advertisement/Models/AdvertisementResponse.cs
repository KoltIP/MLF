using AutoMapper;
using PetProject.AdvertisementServices.Models;

namespace PetProject.Api.Controllers.Advertisement.Models
{
    public class AdvertisementResponse
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string PetName { get; set; } = string.Empty;
        public string PetDescription { get; set; } = string.Empty;
        public float Price { get; set; }
        public int PetColorId { get; set; }
        public string PetColor { get; set; } = string.Empty;
        public int PetBreedId { get; set; }
        public string PetBreed { get; set; } = string.Empty;
        public int PetTypeId { get; set; }
        public string PetType { get; set; } = string.Empty;
        //public DateTime Age { get; set; }
        //public DateTime CreatedDate { get; set; }
    }
    public class AdvertismentResponseProfile : Profile
    {
        public AdvertismentResponseProfile()
        {
            CreateMap<AdvertisementModel, AdvertisementResponse>();
        }
    }
}
