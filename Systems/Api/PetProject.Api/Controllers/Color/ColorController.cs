using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetProject.Api.Controllers.Color.Models;
using PetProject.ColorServices;
using PetProject.ColorServices.Models;
using PetProject.PetServices;

namespace PetProject.Api.Controllers.Color
{
    [Route("api/v{version:apiVersion}/color")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ColorController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<ColorController> logger;
        private readonly IColorService service;

        public ColorController(IMapper mapper,
            ILogger<ColorController> logger,
            IColorService colorService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.service = colorService;
        }

        [HttpGet("{id}")]
        public async Task<ColorResponse> GetColorById([FromRoute] int id)
        {
            var color = await service.GetColor(id);
            var response = mapper.Map<ColorResponse>(color);
            return response;
        }

        [HttpGet("")]
        public async Task<IEnumerable<ColorResponse>> GetColors([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var colors = await service.GetColors(offset, limit);
            var response = mapper.Map<IEnumerable<ColorResponse>>(colors);
            return response;
        }

        [HttpPost("")]
        public async Task<ColorResponse> AddColor([FromQuery] AddColorRequest request)
        {
            var model = mapper.Map<AddColorModel>(request);
            var color = await service.AddColor(model);
            var response = mapper.Map<ColorResponse>(color);
            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditColor([FromRoute] int id, [FromQuery] EditColorRequest request)
        {
            var model = mapper.Map<EditColorModel>(request);

            await service.EditColor(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor([FromRoute] int id)
        {
            await service.DeleteColor(id);

            return Ok();
        }
    }
}
