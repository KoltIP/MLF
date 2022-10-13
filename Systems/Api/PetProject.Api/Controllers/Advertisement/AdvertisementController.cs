using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetProject.AdvertisementServices;
using PetProject.AdvertisementServices.Models;
using PetProject.Api.Controllers.Advertisement.Models;

namespace PetProject.Api.Controllers.Advertisement
{
    [Route("api/v{version:apiVersion}/advertisement")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AdvertisementController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<AdvertisementController> logger;
        private readonly IAdvertisementService advertisementService;

        public AdvertisementController(IMapper mapper,
            ILogger<AdvertisementController> logger,
            IAdvertisementService advertisementService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.advertisementService = advertisementService;
        }

        [HttpGet("{id}")]
        public async Task<AdvertisementResponse> GetAdvertisementById([FromRoute] int id)
        {
            var advertisement = await advertisementService.GetAdvertisement(id);
            var response = mapper.Map<AdvertisementResponse>(advertisement);
            return response;
        }

        [HttpGet("")]
        public async Task<IEnumerable<AdvertisementResponse>> GetAdvertisements([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var advertisements = await advertisementService.GetAdvertisements(offset, limit);
            var response = mapper.Map<IEnumerable<AdvertisementResponse>>(advertisements);
            return response;
        }

        [HttpPost("")]
        public async Task<AdvertisementResponse> AddAdvertisement([FromBody] AddAdvertisementRequest request)
        {
            Console.WriteLine("||||||||||||||||||||||START CONTROLLER||||||||||||||||||||||||");
            var model = mapper.Map<AddAdvertisementModel>(request);
            var advertisement = await advertisementService.AddAdvertisement(model);
            var response = mapper.Map<AdvertisementResponse>(advertisement);
            Console.WriteLine("||||||||||||||||||" + response.Id + "||||||||||||||||||||||");
            Console.WriteLine("||||||||||||||||||" + response.PetName + "||||||||||||||||||||||");
            Console.WriteLine("||||||||||||||||||" + response.PetDescription + "||||||||||||||||||||||");
            Console.WriteLine("||||||||||||||||||" + response.PetBreed + "||||||||||||||||||||||");
            Console.WriteLine("||||||||||||||||||" + response.PetBreedId + "||||||||||||||||||||||");
            Console.WriteLine("||||||||||||||||||" + response.PetTypeId + "||||||||||||||||||||||");
            Console.WriteLine("||||||||||||||||||" + response.PetType + "||||||||||||||||||||||");
            Console.WriteLine("||||||||||||||||||" + response.PetColor + "||||||||||||||||||||||");
            Console.WriteLine("||||||||||||||||||" + response.PetColorId + "||||||||||||||||||||||");
            Console.WriteLine("||||||||||||||||||" + response.Price + "||||||||||||||||||||||");
            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAdvertisement([FromRoute] int id, [FromBody] EditAdvertisementRequest request)
        {
            var model = mapper.Map<EditAdvertisementModel>(request);

            await advertisementService.EditAdvertisement(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvertisement([FromRoute] int id)
        {
            await advertisementService.DeleteAdvertisement(id);

            return Ok();
        }
    }
}
