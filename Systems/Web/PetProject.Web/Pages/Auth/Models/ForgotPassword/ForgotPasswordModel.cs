using FluentValidation;

namespace PetProject.Web.Pages.Auth.Models.ForgotPassword
{
    public class ForgotPasswordModel
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }

    public class ForgotPasswordModelValidator : AbstractValidator<ForgotPasswordModel>
    {
        public ForgotPasswordModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Адрес электронной почты не может быть пуст")
                .MaximumLength(100).WithMessage("Адрес электронной почты слишком длинный.")
                .EmailAddress().WithMessage("Адрес электронной почты обязателен.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль не может быть пуст.")
                .MaximumLength(100).WithMessage("Пароль слишком длинный.")
                .MinimumLength(3).WithMessage("Пароль слишком короткий.");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ForgotPasswordModel>.CreateWithOptions((ForgotPasswordModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
