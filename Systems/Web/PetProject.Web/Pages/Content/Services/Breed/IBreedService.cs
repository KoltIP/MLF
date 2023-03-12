using PetProject.Web.Pages.Advertisement.Models.Breed;
using PetProject.Web.Pages.Content.Models.Breed;
using PetProject.Web.Pages.Profile.Models;

namespace PetProject.Web.Pages.Advertisement.Services.Breed
{
    public interface IBreedService
    {
        Task<ErrorResponse> AddBreed(BreedModel model);
        Task<BreedListItems> GetBreed(int advertisementId);
        Task<IEnumerable<BreedListItems>> GetBreeds(int offset = 0, int limit = 10);
        Task<IEnumerable<BreedListItems>> GetBreedsWithTypeId(int typeId, int offset = 0, int limit = 10);
        Task<ErrorResponse> EditBreed(int breedId, BreedModel model);
        Task<ErrorResponse> DeleteBreed(int breedId);
    }
}
