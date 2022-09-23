using FluentValidation;

namespace PetProject.Web.Pages.Auth.Models.ForgotPassword
{
    public class ForgotPasswordResponse
    {
        public bool Successful { get; set; }
        public string? ErrorDescription { get; set; }
        public string? Error { get; set; }
    }
}
