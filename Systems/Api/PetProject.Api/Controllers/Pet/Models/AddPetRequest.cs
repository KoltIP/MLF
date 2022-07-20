using AutoMapper;
using FluentValidation;
using PetProject.PetServices.Models;

namespace PetProject.Api.Controllers.Pet.Models
{
    public class AddPetRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ColorId { get; set; }
        public int TypeId { get; set; }        
    }

    public class AddPetRequestValidator : AbstractValidator<AddPetRequest>
    {
        public AddPetRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description is long.");
        }
    }

    public class AddPetRequestProfile : Profile
    {
        public AddPetRequestProfile()
        {
            CreateMap<AddPetRequest, AddPetModel>();
        }
    }
}
