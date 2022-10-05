using AutoMapper;
using FluentValidation;
using PetProject.TypeServices.Models;

namespace PetProject.Api.Controllers.Type.Models
{
    public class AddTypeRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class AddTypeRequestValidator : AbstractValidator<AddTypeRequest>
    {
        public AddTypeRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description is long.");
        }
    }

    public class AddTypeRequestProfile : Profile
    {
        public AddTypeRequestProfile()
        {
            CreateMap<AddTypeRequest, AddTypeModel>();
        }
    }
}
