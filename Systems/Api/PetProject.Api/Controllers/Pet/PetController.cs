using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetProject.Api.Controllers.Pet.Models;
using PetProject.PetServices;
using PetProject.PetServices.Models;

namespace PetProject.Api.Controllers.Pet
{
    [Route("api/v{version:apiVersion}/pet")]
    [ApiController]
    [ApiVersion("1.0")]
    public class PetController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<PetController> logger;
        private readonly IPetService service;

        public PetController(IMapper mapper,
            ILogger<PetController> logger,
            IPetService petService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.service = petService;
        }

        [HttpGet("{id}")]
        public async Task<PetResponse> GetPetById([FromRoute] int id)
        {
            var pet = await service.GetPet(id);
            var response = mapper.Map<PetResponse>(pet);
            return response;
        }

        [HttpGet("")]
        public async Task<IEnumerable<PetResponse>> GetPets([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var pets = await service.GetPets(offset,limit) ;
            var response = mapper.Map<IEnumerable<PetResponse>>(pets);
            return response;
        }

        [HttpPost("")]
        public async Task<PetResponse> AddPet([FromQuery] AddPetRequest request)
        {
            var model = mapper.Map<AddPetModel>(request);
            var pet = await service.AddPet(model);
            var response = mapper.Map<PetResponse>(pet);
            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPet([FromRoute] int id, [FromQuery] EditPetRequest request)
        {
            var model = mapper.Map<EditPetModel>(request);
                        
            await service.EditPet(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet([FromRoute] int id)
        {           
            await service.DeletePet(id);

            return Ok();
        }
    }
}
