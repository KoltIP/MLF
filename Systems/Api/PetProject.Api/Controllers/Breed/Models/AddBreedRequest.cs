using AutoMapper;
using FluentValidation;
using PetProject.BreedServices.Models;

namespace PetProject.Api.Controllers.Breed.Models
{
    public class AddBreedRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class AddBreedRequestValidator : AbstractValidator<AddBreedRequest>
    {
        public AddBreedRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");
        }
    }

    public class AddBreedRequestProfile : Profile
    {
        public AddBreedRequestProfile()
        {
            CreateMap<AddBreedRequest, AddBreedModel>();
        }
    }
}
