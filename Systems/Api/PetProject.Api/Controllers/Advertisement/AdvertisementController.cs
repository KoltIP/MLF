using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetProject.AdvertisementServices;
using PetProject.AdvertisementServices.Models.Advertisement;
using PetProject.Api.Controllers.Advertisement.Models.Advertisement;
using PetProject.Api.Controllers.Advertisement.Models.File;
using PetProject.Api.Controllers.Advertisement.Models.Filter;
using PetProject.Api.Controllers.Favourite.Models;
using PetProject.Api.Controllers.Subscribe.Models;
using PetProject.FilterService;
using PetProject.FilterService.Models;

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

        public AdvertisementController(IMapper mapper,
            ILogger<AdvertisementController> logger,
             IFilterService filterService,
            IAdvertisementService advertisementService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.filterService = filterService;
            this.advertisementService = advertisementService;
        }


        [HttpGet("{id}")]
        public async Task<AdvertisementResponse> GetAdvertisementById([FromRoute] int id)
        {            
            var advertisement = await advertisementService.GetAdvertisement(id);
            var response = mapper.Map<AdvertisementResponse>(advertisement);
            return response;
        }

        [HttpGet("all/{userGuid}&{pageNumber}")]
        public async Task<AdvertisementResponseList> GetAdvertisements([FromRoute] Guid userGuid, [FromRoute] int pageNumber)
        {
            var filter = await filterService.GetFilter(userGuid);
            if (filter != null)
            {
                var filteredAdvertisements = await advertisementService.FilterAdvertisement(filter, pageNumber);
                var filteredResponse = mapper.Map<AdvertisementResponseList>(filteredAdvertisements);
                return filteredResponse;
            }
            var advertisementsModelList = await advertisementService.GetAdvertisements(pageNumber);
            var response = mapper.Map<AdvertisementResponseList>(advertisementsModelList);
            return response;
        }

        [HttpPost("")]
        public async Task<AdvertisementResponse> AddAdvertisement([FromBody] AddAdvertisementRequest request)
        {
            //add advertisement
            var model = mapper.Map<AddAdvertisementModel>(request);
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

        [HttpPost("addfilter/{pageNumber}")]
        public async Task<AdvertisementResponseList> AddOrEditFilterAdvertisement([FromRoute] int pageNumber, [FromBody] FilterRequest request)
        {
            var model = mapper.Map<FilterModel>(request);
            await filterService.AddOrEditFilter(model);
            var advertisements = await advertisementService.FilterAdvertisement(model, pageNumber);
            var response = mapper.Map<AdvertisementResponseList>(advertisements);
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

        [HttpGet("getFile")]
        public async Task<FileResponse> GetFileAsync()
        {
            var fileModel = await advertisementService.GetFile();

            FileResponse fileResponse = new FileResponse()
            {
                Id = fileModel.Id,
                AdvertisementId = fileModel.AdvertisementId,
                Content = fileModel.Content,
                ContentType = fileModel.ContentType,
            };
            return fileResponse;
        }
    }
}
