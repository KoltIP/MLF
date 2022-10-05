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
    public class EditColorModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class EditColorResponseValidator : AbstractValidator<EditColorModel>
    {
        public EditColorResponseValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");
        }
    }

    public class EditColorRequestProfile : Profile
    {
        public EditColorRequestProfile()
        {
            CreateMap<EditColorModel, Color>();
        }
    }
}
