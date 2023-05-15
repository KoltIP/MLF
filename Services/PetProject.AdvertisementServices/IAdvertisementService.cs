using PetProject.AdvertisementServices.Models.Advertisement;
using PetProject.AdvertisementServices.Models.File;
using PetProject.FilterService.Models;

namespace PetProject.AdvertisementServices
{
    public interface IAdvertisementService
    {
        Task<AdvertisementsModelList> GetAdvertisements(int pageNumber);
        Task<AdvertisementModel> GetAdvertisement(int id);
        Task<AdvertisementsModelList> GetUserAdvertisements(Guid userGuid, int pageNumber);
        Task<AdvertisementModel> AddAdvertisement(AddAdvertisementModel model);
        Task EditAdvertisement(int id, EditAdvertisementModel model);
        Task DeleteAdvertisement(int id);
        Task<AdvertisementsModelList> FilterAdvertisement(FilterModel filter, int pageNumber);
        Task<FileResponseModel> GetFile();
    }
}
