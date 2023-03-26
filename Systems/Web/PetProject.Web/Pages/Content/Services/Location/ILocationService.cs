using PetProject.Web.Pages.Content.Models.City;

namespace PetProject.Web.Pages.Content.Services.Location
{
    public interface ILocationService
    {
        Task<IEnumerable<CityModel>> GetCitiesAsync();
    }
}
