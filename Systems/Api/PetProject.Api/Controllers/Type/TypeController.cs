using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetProject.Api.Controllers.Type.Models;
using PetProject.TypeServices;
using PetProject.TypeServices.Models;

namespace PetProject.Api.Controllers.Type
{
    [Route("api/v{version:apiVersion}/type")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TypeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<TypeController> logger;
        private readonly ITypeService service;

        public TypeController(IMapper mapper,
            ILogger<TypeController> logger,
            ITypeService typeService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.service = typeService;
        }

        [HttpGet("{id}")]
        public async Task<TypeResponse> GetTypeById([FromRoute] int id)
        {
            var type = await service.GetType(id);
            var response = mapper.Map<TypeResponse>(type);
            return response;
        }

        [HttpGet("")]
        public async Task<IEnumerable<TypeResponse>> GetTypes([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var types = await service.GetTypes(offset, limit);
            var response = mapper.Map<IEnumerable<TypeResponse>>(types);
            return response;
        }

        [HttpPost("")]
        public async Task<TypeResponse> AddType([FromQuery] AddTypeRequest request)
        {
            var model = mapper.Map<AddTypeModel>(request);
            var type = await service.AddType(model);
            var response = mapper.Map<TypeResponse>(type);
            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditType([FromRoute] int id, [FromQuery] EditTypeRequest request)
        {
            var model = mapper.Map<EditTypeModel>(request);

            await service.EditType(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType([FromRoute] int id)
        {
            await service.DeleteType(id);

            return Ok();
        }
    }
}
