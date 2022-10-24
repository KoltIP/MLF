using FluentValidation;

namespace PetProject.Web.Pages.Profile.Models
{
    public class NicknameModel
    {
        public string Nickname { get; set; }
    }

    public class NicknameModelValidator : AbstractValidator<NicknameModel>
    {
        public NicknameModelValidator()
        {
            RuleFor(x => x.Nickname)
                .NotEmpty().WithMessage("Nickname is empty.")
                .MaximumLength(100).WithMessage("Nickname is long.");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<NicknameModel>.CreateWithOptions((NicknameModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }

}
