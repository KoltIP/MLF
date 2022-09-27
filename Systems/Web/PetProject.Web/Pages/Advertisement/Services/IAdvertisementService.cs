using PetProject.Shared.Common.Response;
using PetProject.Web.Pages.Advertisement.Models;

namespace PetProject.Web.Pages.Advertisement.Services
{
    public interface IAdvertisementService
    {
        Task<ErrorResponse> AddAdvertisement(AdvertisementModel model);
        Task<AdvertisementList> GetAdvertisement(int advertisementId);
        Task<IEnumerable<AdvertisementList>> GetAdvertisements(int offset = 0, int limit = 10);
        Task<ErrorResponse> EditAdvertisement(int advertisementId, AdvertisementModel model);
        Task<ErrorResponse> DeleteAdvertisement(int advertisementId);
    }
}
