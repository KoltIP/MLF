using AutoMapper;
using FluentValidation;
using PetProject.ColorServices.Models;

namespace PetProject.Api.Controllers.Color.Models
{
    public class AddColorRequest
    {
        public string Name { get; set; } = string.Empty;
    }

    public class AddColorRequestValidator : AbstractValidator<AddColorRequest>
    {
        public AddColorRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");
        }
    }

    public class AddPetRequestProfile : Profile
    {
        public AddPetRequestProfile()
        {
            CreateMap<AddColorRequest, AddColorModel>();
        }
    }
}
