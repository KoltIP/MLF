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
    public class EditPetModel
    {        
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ColorId { get; set; }
        public int TypeId { get; set; }
        public int BreedId { get; set; }
    }

    public class EditPetResponseValidator : AbstractValidator<EditPetModel>
    {
        public EditPetResponseValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name is long.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description is long.");
        }
    }

    public class EditPetRequestProfile : Profile
    {
        public EditPetRequestProfile()
        {
            CreateMap<EditPetModel, Pet>()
                .ForMember(d => d.PetTypeId, a => a.MapFrom(s => s.TypeId));
        }
    }
}
