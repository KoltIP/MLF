
using PetProject.Web.Pages.Advertisement.Models;
using PetProject.Web.Shared.Models;

namespace PetProject.Web.Pages.Advertisement.Services
{
    public interface IAdvertisementService
    {
        Task<ErrorResponse> AddAdvertisement(AdvertisementModel model);
        Task<AdvertisementListItems> GetAdvertisement(int advertisementId);
        Task<IEnumerable<AdvertisementListItems>> GetAdvertisements(int offset = 0, int limit = 10);
        Task<ErrorResponse> EditAdvertisement(int advertisementId, AdvertisementModel model);
        Task<ErrorResponse> DeleteAdvertisement(int advertisementId);
    }
}
