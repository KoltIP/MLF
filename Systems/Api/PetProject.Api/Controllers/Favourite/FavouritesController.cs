using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetProject.AdvertisementServices;
using PetProject.AdvertisementServices.Models;
using PetProject.Api.Controllers.Advertisement.Models;
using PetProject.Api.Controllers.Favourite.Models;
using PetProject.Api.Controllers.Subscribe.Models;

namespace PetProject.Api.Controllers.Favourite
{
    [Route("api/v{version:apiVersion}/favourite")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FavouritesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<FavouritesController> logger;
        private readonly IAdvertisementService advertisementService;

        public FavouritesController(IMapper mapper,
            ILogger<FavouritesController> logger,
            IAdvertisementService advertisementService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.advertisementService = advertisementService;
        }

        [HttpGet("{UserId}")]
        public async Task<IEnumerable<AdvertisementResponse>> GetFavourites([FromRoute] Guid UserId)
        {
            int limit = 10;
            int offset = 0;
            var advertisements = await advertisementService.GetAdvertisements(offset, limit);
            var response = mapper.Map<IEnumerable<AdvertisementResponse>>(advertisements);
            return response;
        }

        [HttpPost("add/")]
        public async Task<IActionResult> AddInFavouriteAsync([FromBody] AddFavouriteRequest request)
        {
            var model = mapper.Map<AddFavouriteModel>(request);
            await advertisementService.AddInFavourite(model);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInFavourite([FromRoute] int id)
        {
            await advertisementService.DeleteInFavourite(id);
            return Ok();
        }        
    }
}
