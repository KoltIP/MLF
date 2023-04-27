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
        public bool Gender { get; set; }
        public bool IsWanted { get; set; }
        public string? PetName { get; set; } = string.Empty;
        public string? PetDescription { get; set; } = string.Empty;
        public float? Price { get; set; }
        public int PetColorId { get; set; }
        public int PetTypeId { get; set; }
        public int CityId { get; set; }
        public int? Age { get; set; }
        public DateTime? DateLost { get; set; }
        public List<AddFileModel> Images { get; set; }
    }

    public class AddAdvertisementResponseValidator : AbstractValidator<AddAdvertisementModel>
    {
        public AddAdvertisementResponseValidator()
        {
            //RuleFor(x => x.UserId)
            //     .NotEmpty().WithMessage("userID is required");
            //RuleFor(x => x.PetName)
            //    .NotEmpty().WithMessage("PetName is required");
            //RuleFor(x => x.PetDescription)
            //    .NotEmpty().WithMessage("PetDescription is required");
            //RuleFor(x => x.Price)
            //    .NotEmpty().WithMessage("Price is required");
            //RuleFor(x => x.PetColorId)
            //    .NotEmpty().WithMessage("PetColorId is required");
            ////RuleFor(x => x.PetBreedId)
            ////    .NotEmpty().WithMessage("PetBreedId is required");
            //RuleFor(x => x.PetTypeId)
            //    .NotEmpty().WithMessage("PetTypeId  is required");
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
