using AutoMapper;
using FluentValidation;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.SubscribeService.Models
{
    public class AddSubscribeModel
    {
        public Guid UserId { get; set; }
        public int AdvertisementId { get; set; }
    }
    public class AddSubscribeModelValidator : AbstractValidator<AddSubscribeModel>
    {
        public AddSubscribeModelValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User is required");
            RuleFor(x => x.AdvertisementId)
                .NotEmpty().WithMessage("Advertisement is required");
        }
    }
    public class AddSubscribeModelProfile : Profile
    {
        public AddSubscribeModelProfile()
        {
            CreateMap<AddSubscribeModel, Subscription>();
        }
    }
}
