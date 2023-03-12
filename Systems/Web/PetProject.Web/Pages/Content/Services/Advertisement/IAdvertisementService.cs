using PetProject.Web.Pages.Advertisement.Models.Advertisement;
using PetProject.Web.Pages.Advertisement.Models.Breed;
using PetProject.Web.Pages.Advertisement.Models.Color;
using PetProject.Web.Pages.Advertisement.Models.Type;
using PetProject.Web.Pages.Profile.Models;

namespace PetProject.Web.Pages.Advertisement.Services.Advertisement
{
    public interface IAdvertisementService
    {
        Task<ErrorResponse> AddAdvertisement(AdvertisementModel model);
        Task<AdvertisementListItems> GetAdvertisement(int advertisementId);
        Task<IEnumerable<AdvertisementListItems>> GetAdvertisements(int offset = 0, int limit = 10);
        Task<IEnumerable<AdvertisementListItems>> GetUserAdvertisements(int offset = 0, int limit = 10);
        Task<ErrorResponse> EditAdvertisement(int advertisementId, AdvertisementModel model);
        Task<ErrorResponse> DeleteAdvertisement(int advertisementId);
        Task<IEnumerable<BreedModel>> GetBreedList();
        Task<IEnumerable<BreedModel>> GetBreedsWithTypeId(int typeId, int offset = 0, int limit = 10);
        Task<IEnumerable<ColorModel>> GetColorList();
        Task<IEnumerable<TypeModel>> GetTypeList();
        Task<IEnumerable<AdvertisementListItems>> GetAllSubscribe();
        Task AddSubscribe(int advertisementId);
        Task<ErrorResponse> DropSubscribe(int id);
        Task<IEnumerable<AdvertisementListItems>> GetAllFavourite();
        Task AddInFavourite(int advertisementId);
        Task<ErrorResponse> DropInFavourite(int id);
    }
}
