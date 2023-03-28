using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetProject.AdvertisementServices.Models;
using PetProject.Api.Controllers.Advertisement.Models;
using PetProject.Api.Controllers.Subscribe.Models;
using PetProject.Api.Controllers.Subscribe;
using PetProject.FileService;
using PetProject.FileService.Models;
using PetProject.Api.Controllers.File.Models;

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
        public async Task<IActionResult> AddFileAsync([FromBody] AddFileRequest request)
        {
            AddFileModel model = new AddFileModel()
            {
                Content = request.Content,
                ContentType = request.ContentType,
            };
            await fileService.AddFile(model);

            return Ok();
        }

        [HttpGet("getFile")]
        public async Task<FileResponse> GetFileAsync()
        {
            var fileModel = await fileService.GetFile();

            var folderName = "//StaticFiles//Images";

            FileResponse fileResponse = new FileResponse()
            {
                Content = fileModel.Content,
                ContentType = fileModel.ContentType,
            };
            return fileResponse;
        }

        [HttpGet("getFiles")]
        public async Task<IEnumerable<FileResponse>> GetFilesAsync()
        {
            var filesModel = (await fileService.GetFiles()).ToList();

            List<FileResponse> result = new List<FileResponse>();
            for (int i=0;i<filesModel.Count();i++)
            { 
                FileResponse item = new FileResponse()
                {
                    Content = filesModel[i].Content,
                    ContentType = filesModel[i].ContentType,
                };
                result.Add(item);
            }
            return result;
        }
    }
}
