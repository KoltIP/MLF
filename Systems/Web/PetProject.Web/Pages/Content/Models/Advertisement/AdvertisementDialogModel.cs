using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;
using PetProject.Web.Pages.Content.Models.File;

namespace PetProject.Web.Pages.Advertisement.Models.Advertisement
{
    public class AdvertisementDialogModel
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
        public FileModel File { get; set; }
    }

    public class AdvertisementDialogModelValidator : AbstractValidator<AdvertisementDialogModel>
    {
        public AdvertisementDialogModelValidator()
        {
            //RuleFor(v => v.UserId).NotEmpty().NotNull().WithMessage("error in web, UserID must be not empty/not null");
            //RuleFor(v => v.PetColorId).NotEmpty().NotNull().WithMessage("error in web, ColorId must be not empty/not null");
            //RuleFor(v => v.PetBreedId).NotEmpty().NotNull().WithMessage("error in web, BreedId must be not empty/not null");
            //RuleFor(v => v.PetTypeId).NotEmpty().NotNull().WithMessage("error in web, TypeID must be not empty/not null");
            //RuleFor(v => v.File).NotEmpty().NotNull().WithMessage("error in web, TypeID must be not empty/not null");
        }

        public Func<object, object, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<AdvertisementDialogModel>.CreateWithOptions((AdvertisementDialogModel)model, x => x.IncludeProperties((string)propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
