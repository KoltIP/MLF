using AutoMapper;
using FluentValidation;
using PetProject.ColorServices.Models;

namespace PetProject.Api.Controllers.Color.Models
{
    public class EditColorRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class EditColorRequestValidator : AbstractValidator<EditColorRequest>
    {
        public EditColorRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");
        }
    }

    public class EditPetRequestProfile : Profile
    {
        public EditPetRequestProfile()
        {
            CreateMap<EditColorRequest, EditColorModel>();
        }
    }
}
