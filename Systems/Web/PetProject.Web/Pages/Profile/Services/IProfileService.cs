using PetProject.Web.Pages.Profile.Models;

namespace PetProject.Web.Pages.Profile.Services
{
    public interface IProfileService
    {
        Task<ProfileModel> GetProfile();
    }
}
