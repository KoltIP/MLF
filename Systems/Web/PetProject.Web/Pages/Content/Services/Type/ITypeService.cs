using PetProject.Web.Pages.Advertisement.Models.Type;
using PetProject.Web.Pages.Content.Models.Type;
using PetProject.Web.Pages.Profile.Models;

namespace PetProject.Web.Pages.Advertisement.Services.Type
{
    public interface ITypeService
    {
        Task<ErrorResponse> AddType(TypeModel model);
        Task<TypeListItems> GetType(int typeId);
        Task<IEnumerable<TypeListItems>> GetTypies(int offset = 0, int limit = 10);
        Task<ErrorResponse> EditType(int typeId, TypeModel model);
        Task<ErrorResponse> DeleteType(int typeId);
    }
}
