using AutoMapper;
using FluentValidation;
using PetProject.BreedServices.Models;

namespace PetProject.Api.Controllers.Breed.Models
{
    public class EditBreedRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class EditBreedRequestValidator : AbstractValidator<EditBreedRequest>
    {
        public EditBreedRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");
        }
    }

    public class EditBreedRequestProfile : Profile
    {
        public EditBreedRequestProfile()
        {
            CreateMap<EditBreedRequest, EditBreedModel>();
        }
    }
}
