using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetProject.Api.Controllers.Advertisement.Models;
using PetProject.Api.Controllers.Breed.Models;
using PetProject.BreedServices;
using PetProject.BreedServices.Models;

namespace PetProject.Api.Controllers.Breed
{
    [Route("api/v{version:apiVersion}/breed")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BreedController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<BreedController> logger;
        private readonly IBreedService service;

        public BreedController(IMapper mapper,
            ILogger<BreedController> logger,
            IBreedService breedService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.service = breedService;
        }


        [HttpGet("with/TypeId/{typeId}")]
        public async Task<IEnumerable<BreedResponse>> GetBreedsWithTypeId([FromRoute] int typeId, [FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var breeds = await service.GetBreedsWithTypeId(typeId, offset, limit);
            var response = mapper.Map<IEnumerable<BreedResponse>>(breeds);
            return response;
        }


        [HttpGet("{id}")]
        public async Task<BreedResponse> GetBreedById([FromRoute] int id)
        {
            var breed = await service.GetBreed(id);
            var response = mapper.Map<BreedResponse>(breed);
            return response;
        }

        [HttpGet("")]
        public async Task<IEnumerable<BreedResponse>> GetBreeds([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var breeds = await service.GetBreeds(offset, limit);
            var response = mapper.Map<IEnumerable<BreedResponse>>(breeds);
            return response;
        }

        [HttpPost("")]
        public async Task<BreedResponse> AddBreed([FromQuery] AddBreedRequest request)
        {
            var model = mapper.Map<AddBreedModel>(request);
            var pet = await service.AddBreed(model);
            var response = mapper.Map<BreedResponse>(pet);
            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBreed([FromRoute] int id, [FromQuery] EditBreedRequest request)
        {
            var model = mapper.Map<EditBreedModel>(request);

            await service.EditBreed(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed([FromRoute] int id)
        {
            await service.DeleteBreed(id);

            return Ok();
        }
    }
}
