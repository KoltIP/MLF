using AutoMapper;
using FluentValidation;
using PetProject.PetServices.Models;

namespace PetProject.Api.Controllers.Pet.Models
{
    public class EditPetRequest
    {
        public string Name { get; set; } = string.Empty;
        public int ColorId { get; set; }
        public int TypeId { get; set; }        
    }

    public class EditPetRequestValidator : AbstractValidator<EditPetRequest>
    {
        public EditPetRequestValidator()
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
            CreateMap<EditPetRequest, EditPetModel>();
        }
    }

}
