using PetProject.Web.Pages.Advertisement.Models.Advertisement;
using PetProject.Web.Pages.Content.Models.Advertisement;
using PetProject.Web.Pages.Profile.Models;

namespace PetProject.Web.Pages.Content.Services.Favourite
{
    public interface IFavouriteService
    {
        Task<AdvertisementResponseList> GetAllFavourite(int pageNumber);
        Task AddInFavourite(int advertisementId);
        Task<ErrorResponse> DropInFavourite(int id);
    }
}
