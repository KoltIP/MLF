using AutoMapper;
using FluentValidation;
using PetProject.TypeServices.Models;

namespace PetProject.Api.Controllers.Type.Models
{
    public class EditTypeRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }
        public int BreedId { get; set; }
    }

    public class EditTypeRequestValidator : AbstractValidator<EditTypeRequest>
    {
        public EditTypeRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description is long.");
        }
    }

    public class EditTypeRequestProfile : Profile
    {
        public EditTypeRequestProfile()
        {
            CreateMap<EditTypeRequest, EditTypeModel>();
        }
    }
}
