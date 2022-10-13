using FluentValidation;

namespace PetProject.Web.Pages.Advertisement.Models
{
    public class AdvertisementModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string PetName { get; set; } = string.Empty;
        public string PetDescription { get; set; } = string.Empty;
        public float Price { get; set; }
        public string PetColor { get; set; } = string.Empty;
        public string PetBreed { get; set; } = string.Empty;
        public string PetType { get; set; } = string.Empty;
    }

    public class AdvertisementModelValidator : AbstractValidator<AdvertisementModel>
    {
        public AdvertisementModelValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull();
            RuleFor(v => v.UserId).NotEmpty().NotNull();
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
