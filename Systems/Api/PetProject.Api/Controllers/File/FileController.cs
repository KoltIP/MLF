using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetProject.AdvertisementServices.Models;
using PetProject.Api.Controllers.Advertisement.Models;
using PetProject.Api.Controllers.Subscribe.Models;
using PetProject.Api.Controllers.Subscribe;
using PetProject.FileService;
using PetProject.FileService.Models;

namespace PetProject.Api.Controllers.File
{
    [Route("api/v{version:apiVersion}/file")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FileController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<FileController> logger;
        private readonly IFileService fileService;

        public FileController(IMapper mapper,
            ILogger<FileController> logger,
            IFileService fileService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.fileService = fileService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddFileAsync([FromBody] List<FileModel> request)
        {
            var model = mapper.Map<List<FileModel>>(request);
            await fileService.Add(model);
            return Ok();
        }
    }
}
