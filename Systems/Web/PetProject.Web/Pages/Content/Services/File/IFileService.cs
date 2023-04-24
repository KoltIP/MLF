using Microsoft.AspNetCore.Components.Forms;
using PetProject.Web.Pages.Content.Models.File;

namespace PetProject.Web.Pages.Content.Services.File
{
    public interface IFileService
    {
        Task SaveFiles(List<FileModel> files);
        Task<FileResponse> GetFile();
        Task<IEnumerable<FileResponse>> GetFiles();
    }
}
