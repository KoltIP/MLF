namespace PetProject.Web.Pages.Auth.Models.Registration
{
    public class RegistrationErrorResponse
    {
        public bool Successful { get; set; }
        public string? Error { get; set; } = string.Empty;
    }
}
