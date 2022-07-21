using PetProject.Web.Pages.Auth.Models;

namespace PetProject.Web.Pages.Auth.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginModel loginModel);
        Task Logout();
    }

}
