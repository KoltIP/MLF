using FluentValidation;

namespace PetProject.Web.Pages.Auth.Models.Registration
{
    public class RegistrationModel
    {

        public string? Email { get; set; }
        public string? Nickname { get; set; }
        public string? Password { get; set; }

    }

    public class RegistrationModelValidator : AbstractValidator<RegistrationModel>
    {
        public RegistrationModelValidator()
        {

            RuleFor(x => x.Email)
                .MaximumLength(100).WithMessage("Email is long.")
                .EmailAddress().WithMessage("Email is required.");

            RuleFor(x => x.Nickname)
               .NotEmpty().WithMessage("User name is required.")
               .MaximumLength(100).WithMessage("User name is long.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MaximumLength(100).WithMessage("Password is long.")
                .MinimumLength(3).WithMessage("Password is short (minimum 3 simbols).");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<RegistrationModel>.CreateWithOptions((RegistrationModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
