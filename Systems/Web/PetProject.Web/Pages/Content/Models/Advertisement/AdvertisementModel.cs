

using FluentValidation;

namespace PetProject.Web.Pages.Advertisement.Models.Advertisement
{
    public class AdvertisementModel
    {   
        public int Id { get; set; }     
        public Guid UserId { get; set; }
        public string? PetName { get; set; } 
        public string? PetDescription { get; set; }
        public float? Price { get; set; }
        public int PetColorId { get; set; }
        public int PetBreedId { get; set; }
        public int PetTypeId { get; set; }
        public int CityId { get; set; }
        public int Age { get; set; }
        public DateTime? DateLost { get; set; }
    }

    public class AdvertisementModelValidator : AbstractValidator<AdvertisementModel>
    {
        public AdvertisementModelValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().NotNull().WithMessage("error in web, UserID must be not empty/not null");
            //RuleFor(v => v.PetName).NotEmpty().NotNull().WithMessage("error in web, Name must be not empty/not null");
            //RuleFor(v => v.PetDescription).NotEmpty().NotNull().WithMessage("error in web, Description must be not empty/not null");            
            //RuleFor(v => v.Price).NotEmpty().NotNull().WithMessage("error in web, Price must be not empty/not null");
            //RuleFor(v => v.PetColorId).NotEmpty().NotNull().WithMessage("error in web, ColorId must be not empty/not null");
            //RuleFor(v => v.PetBreedId).NotEmpty().NotNull().WithMessage("error in web, BreedId must be not empty/not null");
            //RuleFor(v => v.PetTypeId).NotEmpty().NotNull().WithMessage("error in web, TypeID must be not empty/not null");
            
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
