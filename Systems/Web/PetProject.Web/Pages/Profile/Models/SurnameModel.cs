using FluentValidation;

namespace PetProject.Web.Pages.Profile.Models
{
    public class SurnameModel
    {
        public string Surname { get; set; }
    }
    public class SurnameModelValidator : AbstractValidator<SurnameModel>
    {
        public SurnameModelValidator()
        {
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is empty.")
                .MaximumLength(100).WithMessage("Surname is long.");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<SurnameModel>.CreateWithOptions((SurnameModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }

}
