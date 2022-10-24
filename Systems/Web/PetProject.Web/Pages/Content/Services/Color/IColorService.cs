using PetProject.Web.Pages.Advertisement.Models.Color;
using PetProject.Web.Pages.Content.Models.Color;
using PetProject.Web.Pages.Profile.Models;

namespace PetProject.Web.Pages.Advertisement.Services.Color
{
    public interface IColorService
    {
        Task<ErrorResponse> AddColor(ColorModel model);
        Task<ColorListItems> GetColor(int colorId);
        Task<IEnumerable<ColorListItems>> GetColors(int offset = 0, int limit = 10);
        Task<ErrorResponse> EditColor(int colorId, ColorModel model);
        Task<ErrorResponse> DeleteColor(int colorId);
    }
}
