using AutoMapper;
using FluentValidation;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.PetServices.Models
{
    public class AddPetModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ColorId { get; set; }
        public int TypeId { get; set; }
    }

    public class AddPetResponseValidator : AbstractValidator<AddPetModel>
    {
        public AddPetResponseValidator()
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
            CreateMap<AddPetModel, Pet>()
                .ForMember(d => d.PetTypeId, a => a.MapFrom(s => s.TypeId));
        }
    }
}
