using FluentValidation;

namespace PetProject.Web.Pages.Content.Models.Subscribe
{
    public class SubscribeModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int AdvertisementId { get; set; }
    }

    public class SubscribeModelValidator : AbstractValidator<SubscribeModel>
    {
        public SubscribeModelValidator()
        {
            RuleFor(x => x.AdvertisementId)
                .NotEmpty().WithMessage("Content is required");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<SubscribeModel>.CreateWithOptions((SubscribeModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
