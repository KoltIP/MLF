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
    public class AddBreedModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class AddBreedResponseValidator : AbstractValidator<AddBreedModel>
    {
        public AddBreedResponseValidator()
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
            CreateMap<AddBreedModel, Breed>();
        }
    }
}
