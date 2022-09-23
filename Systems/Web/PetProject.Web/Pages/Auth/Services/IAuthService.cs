using PetProject.Web.Pages.Auth.Models.ForgotPassword;
using PetProject.Web.Pages.Auth.Models.Login;
using PetProject.Web.Pages.Auth.Models.Registration;

namespace PetProject.Web.Pages.Auth.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginModel loginModel);
        Task Logout();
        Task<RegistrationErrorResponse> Registration(RegistrationModel registrationModel);
        Task<bool> InspectEmail(string email);
        Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordModel forgotPassword);

    }

}
