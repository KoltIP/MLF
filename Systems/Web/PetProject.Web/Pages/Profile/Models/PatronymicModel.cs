using FluentValidation;

namespace PetProject.Web.Pages.Profile.Models
{
    public class PatronymicModel
    {
        public string Patronymic { get; set; }
    }

    public class PatronymicModelValidator : AbstractValidator<PatronymicModel>
    {
        public PatronymicModelValidator()
        {
            RuleFor(x => x.Patronymic)
                .NotEmpty().WithMessage("Patronymic is empty.")
                .MaximumLength(100).WithMessage("Patronymic is long.");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<PatronymicModel>.CreateWithOptions((PatronymicModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
