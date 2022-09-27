using FluentValidation;

namespace PetProject.Web.Pages.Advertisement.Models
{
    public class AdvertisementModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public float Price { get; set; }
        public int PetId { get; set; }
    }

    public class AdvertisementModelValidator : AbstractValidator<AdvertisementModel>
    {
        public AdvertisementModelValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull();
            RuleFor(v => v.UserId).NotEmpty().NotNull();
            RuleFor(v => v.PetId).NotNull().NotEmpty();
        }

        public Func<object, object, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<AdvertisementModel>.CreateWithOptions((AdvertisementModel)model, x => x.IncludeProperties((string)propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
