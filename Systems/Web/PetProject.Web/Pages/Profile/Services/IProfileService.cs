using PetProject.Web.Pages.Profile.Models;

namespace PetProject.Web.Pages.Profile.Services
{
    public interface IProfileService
    {
        Task<ProfileModel> GetProfile();
        Task<ErrorResponse> ChangeName(NameModel model);
        Task<ErrorResponse> ChangeSurname(SurnameModel model);
        Task<ErrorResponse> ChangePatronymic(PatronymicModel model);
        Task<ErrorResponse> ChangeNickname(NicknameModel model);
        Task<ErrorResponse> ChangeEmail(EmailModel model);
        Task<ErrorResponse> ChangePassword(PasswordModel model);
        Task DeleteProfile();
    }
}
