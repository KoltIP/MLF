using AutoMapper;
using FluentValidation;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.ColorServices.Models
{
    public class AddColorModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class AddColorResponseValidator : AbstractValidator<AddColorModel>
    {
        public AddColorResponseValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");
        }
    }

    public class AddColorRequestProfile : Profile
    {
        public AddColorRequestProfile()
        {
            CreateMap<AddColorModel, Color>();
        }
    }
}
