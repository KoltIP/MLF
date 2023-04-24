using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetProject.AdvertisementServices;
using PetProject.AdvertisementServices.Models;
using PetProject.Api.Controllers.Advertisement.Models;
using PetProject.Api.Controllers.Favourite.Models;
using PetProject.Api.Controllers.Subscribe.Models;
using PetProject.FileService;
using PetProject.FileService.Models;
using PetProject.FilterService;
using PetProject.FilterService.Models;
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
        private readonly IFilterService filterService;
        private readonly IAdvertisementService advertisementService;
        private readonly IFileService fileService;

        public AdvertisementController(IMapper mapper,
            ILogger<AdvertisementController> logger,
             IFilterService filterService,
            IAdvertisementService advertisementService,
            IFileService fileService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.filterService = filterService;
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

        [HttpGet("all/{userGuid}")]
        public async Task<IEnumerable<AdvertisementResponse>> GetAdvertisements([FromRoute] Guid userGuid)
        {
            var filter = await filterService.GetFilter(userGuid);
            if (filter != null)
            {
                var filteredAdvertisements = await advertisementService.FilterAdvertisement(filter);
                var filteredResponse = mapper.Map<IEnumerable<AdvertisementResponse>>(filteredAdvertisements);
                return filteredResponse;
            }
            var advertisements = await advertisementService.GetAdvertisements();
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

        [HttpPost("addfilter")]
        public async Task<IEnumerable<AdvertisementResponse>> AddOrEditFilterAdvertisement([FromBody] FilterRequest request)
        {
            var model = mapper.Map<FilterModel>(request);
            await filterService.AddOrEditFilter(model);
            var advertisements = await advertisementService.FilterAdvertisement(model);
            var response = mapper.Map<IEnumerable<AdvertisementResponse>>(advertisements);
            return response;
        }

        [HttpGet("getfilter/{userGuid}")]
        public async Task<FilterResponse> GetFilterAdvertisement([FromRoute] Guid userGuid)
        {
            var filter = await filterService.GetFilter(userGuid);
            var response = mapper.Map<FilterResponse>(filter);
            return response;
        }


        [HttpDelete("dropfilter/{userGuid}")]
        public async Task<IActionResult> DropFilterAdvertisement([FromRoute] Guid userGuid)
        {
            await filterService.DeleteFilter(userGuid);
            return Ok();
        }
    }
}
