using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetProject.Api.Controllers.Breed.Models;
using PetProject.Api.Controllers.Breed;
using PetProject.LocationService;
using PetProject.Api.Controllers.Location.Models.Cities;

namespace PetProject.Api.Controllers.Location
{
    [Route("api/v{version:apiVersion}/location")]
    [ApiController]
    [ApiVersion("1.0")]
    public class LocationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<LocationController> logger;
        private readonly ILocationService service;

        public LocationController(IMapper mapper,
            ILogger<LocationController> logger,
            ILocationService breedService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.service = breedService;
        }


        [HttpGet("")]
        public async Task<IEnumerable<CityResponse>> GetCitiesAsync()
        {
            var cities =  await service.GetCitiesAsync();
            var response = mapper.Map<IEnumerable<CityResponse>>(cities);
            return response;
        }
    }
}
