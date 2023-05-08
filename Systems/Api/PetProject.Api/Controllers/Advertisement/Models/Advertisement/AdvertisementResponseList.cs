

using AutoMapper;
using PetProject.AdvertisementServices.Models.Advertisement;

namespace PetProject.Api.Controllers.Advertisement.Models.Advertisement
{
    public class AdvertisementResponseList
    {
        public List<AdvertisementResponse> Advertisements { get; set; }
        public int Count { get; set; }
    }

    public class AdvertisementResponseListProfile : Profile
    {
        public AdvertisementResponseListProfile()
        {
            CreateMap<AdvertisementsModelList, AdvertisementResponseList>();
        }
    }

}
