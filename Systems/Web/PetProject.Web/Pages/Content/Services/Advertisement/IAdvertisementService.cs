using PetProject.Web.Pages.Advertisement.Models.Advertisement;
using PetProject.Web.Pages.Advertisement.Models.Breed;
using PetProject.Web.Pages.Advertisement.Models.Color;
using PetProject.Web.Pages.Advertisement.Models.Type;
using PetProject.Web.Pages.Content.Models.Advertisement;
using PetProject.Web.Pages.Content.Models.City;
using PetProject.Web.Pages.Content.Models.File;
using PetProject.Web.Pages.Profile.Models;
using System.Drawing;

namespace PetProject.Web.Pages.Advertisement.Services.Advertisement
{
    public interface IAdvertisementService
    {
        Task<ErrorResponse> AddAdvertisement(AdvertisementDialogModel model);        
        Task<AdvertisementResponse> GetAdvertisement(int advertisementId);
        Task<AdvertisementResponseList> GetAdvertisements(int pageNumber);
        Task<AdvertisementResponseList> GetUserAdvertisements(int pageNumber);
        Task<ErrorResponse> EditAdvertisement(int advertisementId, AdvertisementDialogModel model);
        Task<ErrorResponse> DeleteAdvertisement(int advertisementId);
        Task<IEnumerable<BreedModel>> GetBreedList();
        Task<IEnumerable<BreedModel>> GetBreedsWithTypeId(int typeId, int offset = 0, int limit = 10);
        Task<IEnumerable<ColorModel>> GetColorList();
        Task<IEnumerable<TypeModel>> GetTypeList();
        Task<AdvertisementResponseList> AddFilter(AdvertisementFilterModel filtermodel, int pageNumber);
        Task<AdvertisementFilterModel> GetFilter();
        Task<ErrorResponse> DropFilter();
    }
}
