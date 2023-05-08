using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetProject.AdvertisementServices;
using PetProject.AdvertisementServices.Models;
using PetProject.Api.Controllers.Advertisement.Models.Advertisement;
using PetProject.Api.Controllers.Favourite.Models;
using PetProject.Api.Controllers.Subscribe.Models;
using PetProject.SubscribeService;
using PetProject.SubscribeService.Models;

namespace PetProject.Api.Controllers.Subscribe
{
    [Route("api/v{version:apiVersion}/subscribe")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SubscribeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<SubscribeController> logger;
        private readonly ISubscribeService subscribeService;

        public SubscribeController(IMapper mapper,
            ILogger<SubscribeController> logger,
            ISubscribeService subscriveService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.subscribeService = subscriveService;
        }

        [HttpGet("{UserId}")]
        public async Task<IEnumerable<AdvertisementResponse>> GetSubscribsions([FromRoute] Guid UserId)
        {
            int limit = 10;
            int offset = 0;
            var advertisements = await subscribeService.GetAllSubscribe(UserId);
            var response = mapper.Map<IEnumerable<AdvertisementResponse>>(advertisements);
            return response;
        }

        [HttpPost("add/")]
        public async Task<IActionResult> AddSubscribeAsync([FromBody] AddSubscribeRequest request)
        {
            var model = mapper.Map<AddSubscribeModel>(request);
            await subscribeService.AddSubscribe(model);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscribe([FromRoute] int id)
        {
            await subscribeService.DeleteSubscribe(id);
            return Ok();
        }


    }
}


