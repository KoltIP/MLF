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
    }
    public class AdvertismentResponseProfile : Profile
    {
        public AdvertismentResponseProfile()
        {
            CreateMap<AdvertisementModel, AdvertisementResponse>();
        }
    }
}
