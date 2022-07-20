using AutoMapper;
using FluentValidation;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.BreedServices.Models
{
    public class EditBreedModel
    {
        public string Name { get; set; } = string.Empty;
    }

    public class EditBreedResponseValidator : AbstractValidator<EditBreedModel>
    {
        public EditBreedResponseValidator()
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
            CreateMap<EditBreedModel, Breed>();
        }
    }
}
