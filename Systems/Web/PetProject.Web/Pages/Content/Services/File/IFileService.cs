using PetProject.Web.Pages.Content.Models.File;

namespace PetProject.Web.Pages.Content.Services.File
{
    public interface IFileService
    {
        Task SaveFiles(List<FileModel> files);
        Task GetFile();
    }
}
