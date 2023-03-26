using AutoMapper;
using PetProject.Api.Controllers.Breed.Models;
using PetProject.LocationService.Models.Cities;

namespace PetProject.Api.Controllers.Location.Models.Cities
{
    public class CityResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class CityResponseProfile : Profile
    {
        public CityResponseProfile()
        {
            CreateMap<CityModel, CityResponse>();
        }
    }
}
