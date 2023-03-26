using PetProject.Web.Pages.Advertisement.Models.Advertisement;
using PetProject.Web.Pages.Profile.Models;

namespace PetProject.Web.Pages.Content.Services.Subscribe
{
    public interface ISubscribeService
    {
        Task<IEnumerable<AdvertisementListItems>> GetAllSubscribe();
        Task AddSubscribe(int advertisementId);
        Task<ErrorResponse> DropSubscribe(int id);
    }
}
