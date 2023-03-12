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
    public class AddFavouriteModel
    {
        public Guid UserId { get; set; }
        public int AdvertisementId { get; set; }
    }

    public class AddFavouriteModelValidator : AbstractValidator<AddFavouriteModel>
    {
        public AddFavouriteModelValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User is required");
            RuleFor(x => x.AdvertisementId)
                .NotEmpty().WithMessage("Advertisement is required");
        }
    }
    public class AddFavouriteModelProfile : Profile
    {
        public AddFavouriteModelProfile()
        {
            CreateMap<AddFavouriteModel, Favourite>();
        }
    }

}
