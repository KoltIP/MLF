using AutoMapper;
using PetProject.AdvertisementServices.Models;

namespace PetProject.Api.Controllers.Advertisement.Models
{
    public class FilterRequest
    {
        public int? IsWanted { get; set; }
        public float? Price { get; set; }
        public int? PetColorId { get; set; }
        public int? PetBreedId { get; set; }
        public int? PetTypeId { get; set; }
        public int? CityId { get; set; }
        public int? AgeStart { get; set; }
        public int? AgeEnd { get; set; }
        public DateTime? DateLostStart { get; set; }
        public DateTime? DateLostEnd { get; set; }
    }

    public class FilterRequestProfile : Profile
    {
        public FilterRequestProfile()
        {
            CreateMap<FilterRequest, FilterModel>();
        }
    }
}
