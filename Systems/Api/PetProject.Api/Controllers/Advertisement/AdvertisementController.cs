using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetProject.AdvertisementServices;
using PetProject.AdvertisementServices.Models;
using PetProject.Api.Controllers.Advertisement.Models;
using PetProject.Api.Controllers.Favourite.Models;
using PetProject.Api.Controllers.Subscribe.Models;
using PetProject.FileService;
using PetProject.FileService.Models;
using PetProject.Web.Pages.Content.Services.File;
using IFileService = PetProject.FileService.IFileService;

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
        private readonly IFileService fileService;

        public AdvertisementController(IMapper mapper,
            ILogger<AdvertisementController> logger,
            IAdvertisementService advertisementService,
            IFileService fileService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.advertisementService = advertisementService;
            this.fileService = fileService;
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
            //add image
            AddFileModel file = new AddFileModel()
            {
                Content = request.File.Content,
                ContentType = request.File.ContentType,
            };
            var fileId = await fileService.AddFile(file);

            //add advertisement
            var model = mapper.Map<AddAdvertisementModel>(request);
            model.ImageId = fileId;
            var advertisement = await advertisementService.AddAdvertisement(model);
            var response = mapper.Map<AdvertisementResponse>(advertisement);
            
            //return result
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
