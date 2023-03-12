using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetProject.AdvertisementServices;
using PetProject.AdvertisementServices.Models;
using PetProject.Api.Controllers.Advertisement.Models;
using PetProject.Api.Controllers.Favourite.Models;
using PetProject.Api.Controllers.Subscribe.Models;

namespace PetProject.Api.Controllers.Subscribe
{
    [Route("api/v{version:apiVersion}/subscribe")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SubscribeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<SubscribeController> logger;
        private readonly IAdvertisementService advertisementService;

        public SubscribeController(IMapper mapper,
            ILogger<SubscribeController> logger,
            IAdvertisementService advertisementService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.advertisementService = advertisementService;
        }

        [HttpGet("{UserId}")]
        public async Task<IEnumerable<AdvertisementResponse>> GetSubscribsions([FromRoute] Guid UserId)
        {
            int limit = 10;
            int offset = 0;
            var advertisements = await advertisementService.GetAdvertisements(offset, limit);
            var response = mapper.Map<IEnumerable<AdvertisementResponse>>(advertisements);
            return response;
        }

        [HttpPost("add/")]
        public async Task<IActionResult> AddSubscribeAsync([FromBody] AddSubscribeRequest request)
        {
            var model = mapper.Map<AddSubscribeModel>(request);
            await advertisementService.AddSubscribe(model);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscribe([FromRoute] int id)
        {
            await advertisementService.DeleteSubscribe(id);
            return Ok();
        }


    }
}


