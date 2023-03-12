using FluentValidation;
using PetProject.Web.Pages.Content.Models.Subscribe;

namespace PetProject.Web.Pages.Content.Models.Favourite
{
    public class FavouriteModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int AdvertisementId { get; set; }
    }

    public class FavouriteModelValidator : AbstractValidator<FavouriteModel>
    {
        public FavouriteModelValidator()
        {
            RuleFor(x => x.AdvertisementId)
                .NotEmpty().WithMessage("AdvertisementId is required");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<FavouriteModel>.CreateWithOptions((FavouriteModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }

}
