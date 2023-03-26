using AutoMapper;
using FluentValidation;
using PetProject.AdvertisementServices.Models;
using PetProject.FavoutiteService.Models;

namespace PetProject.Api.Controllers.Favourite.Models
{
    public class AddFavouriteRequest
    {
        public Guid UserId { get; set; }
        public int AdvertisementId { get; set; }
    }

    public class AddFavouriteRequestValidator : AbstractValidator<AddFavouriteRequest>
    {
        public AddFavouriteRequestValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User is required");
            RuleFor(x => x.AdvertisementId)
                .NotEmpty().WithMessage("Advertisement is required");
        }
    }
    public class AddFavouriteRequestProfile : Profile
    {
        public AddFavouriteRequestProfile()
        {
            CreateMap<AddFavouriteRequest, AddFavouriteModel>();
        }
    }
}
