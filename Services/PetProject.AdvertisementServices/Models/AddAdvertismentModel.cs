using AutoMapper;
using FluentValidation;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.AdvertisementServices.Models
{
    public class AddAdvertisementModel
    {
        public Guid UserId { get; set; }
        public string PetName { get; set; } = string.Empty;
        public string PetDescription { get; set; } = string.Empty;
        public float Price { get; set; }
        public int PetColorId { get; set; }
        public int PetBreedId { get; set; }
        public int PetTypeId { get; set; }
        //public DateTime Age { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public Importance Importance { get; set; }
    }

    public class AddAdvertisementResponseValidator : AbstractValidator<AddAdvertisementModel>
    {
        public AddAdvertisementResponseValidator()
        {
            RuleFor(x => x.Price)
               .NotEmpty().WithMessage("Price is required.");
        }
    }

    public class AddAdvertisementRequestProfile : Profile
    {
        public AddAdvertisementRequestProfile()
        {
            CreateMap<AddAdvertisementModel, Advertisement>();
        }
    }
}
