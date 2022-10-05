using AutoMapper;
using FluentValidation;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.TypeServices.Models
{
    public class AddTypeModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class AddTypeResponseValidator : AbstractValidator<AddTypeModel>
    {
        public AddTypeResponseValidator()
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
            CreateMap<AddTypeModel, PetType>();
        }
    }
}
