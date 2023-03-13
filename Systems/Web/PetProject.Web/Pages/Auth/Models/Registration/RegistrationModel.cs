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
                .MaximumLength(100).WithMessage("Адрес электронной почты слишком длинный.")
                .EmailAddress().WithMessage("Адрес электронной обязателен.");

            RuleFor(x => x.Nickname)
               .NotEmpty().WithMessage("Имя пользователя обязательно.")
               .MaximumLength(100).WithMessage("Имя пользователя слишком длинное.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль обязателен.")
                .MaximumLength(100).WithMessage("Пароль слишком длинный.")
                .MinimumLength(3).WithMessage("Пароль слишком короткий (минимум 3 символа).");
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
