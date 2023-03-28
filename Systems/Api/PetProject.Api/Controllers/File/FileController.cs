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
                Name = request.Name,
                Size = request.Size,
                Content = request.Content,
                ContentType = request.ContentType,
                ImageDataUrl = request.ImageDataUrl,
            };
            await fileService.AddFile(model);

            var folderName = System.IO.Path.Combine("StaticFiles", "Images");
            var directory = Directory.GetCurrentDirectory();
            var pathToSave = System.IO.Path.Combine(directory, folderName);
            var fullPath = System.IO.Path.Combine(pathToSave, model.Name);            
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                using (var ms = new MemoryStream(model.Content))
                {
                    ms.CopyTo(stream);
                };
            }

            return Ok();
        }

        [HttpGet("")]
        public async Task<FileResponse> GetFileAsync()
        {
            var fileModel = await fileService.GetFile();

            var folderName = "//StaticFiles//Images";
            //var folderName = System.IO.Path.Combine("StaticFiles", "Images");
            //var directory = Directory.GetCurrentDirectory();
            //var pathToSave = System.IO.Path.Combine(directory, folderName);

            FileResponse fileResponse = new FileResponse()
            {
                Content = fileModel.Content,
                ContentType = fileModel.ContentType,
                Id = fileModel.Id,
                //ImageDataUrl = System.IO.Path.Combine(pathToSave, fileModel.ImageDataUrl),
                ImageDataUrl = folderName+"//"+fileModel.ImageDataUrl,
                Size = fileModel.Size,
            };
            return fileResponse;
        }
    }
}
