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
    public class EditAdvertisementModel
    {
        public Guid UserId { get; set; }
        public float Price { get; set; }
        public int PetId { get; set; }
        public string PetColor { get; set; }
        public string PetBreed { get; set; }
        public string PetType { get; set; }
    }

    public class EditAdvertisementResponseValidator : AbstractValidator<EditAdvertisementModel>
    {
        public EditAdvertisementResponseValidator()
        {
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required.");
        }
    }

    public class EditAdvertisementRequestProfile : Profile
    {
        public EditAdvertisementRequestProfile()
        {
            CreateMap<EditAdvertisementModel, Advertisement>();
        }
    }
}
