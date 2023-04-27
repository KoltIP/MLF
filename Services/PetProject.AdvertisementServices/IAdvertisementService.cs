using PetProject.AdvertisementServices.Models;
using PetProject.FilterService.Models;

namespace PetProject.AdvertisementServices
{
    public interface IAdvertisementService
    {
        Task<IEnumerable<AdvertisementModel>> GetAdvertisements();
        Task<AdvertisementModel> GetAdvertisement(int id);
        Task<AdvertisementModel> AddAdvertisement(AddAdvertisementModel model);
        Task EditAdvertisement(int id, EditAdvertisementModel model);
        Task DeleteAdvertisement(int id);
        Task<IEnumerable<AdvertisementModel>> FilterAdvertisement(FilterModel filter);
        Task<FileResponseModel> GetFile();
    }
}
