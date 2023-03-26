using AutoMapper;
using FluentValidation;
using PetProject.AdvertisementServices.Models;
using PetProject.CommentServices.Models;
using PetProject.SubscribeService.Models;

namespace PetProject.Api.Controllers.Subscribe.Models
{
    public class AddSubscribeRequest
    {
        public Guid UserId { get; set; }
        public int AdvertisementId { get; set; }
    }

    public class AddSubscribeRequestValidator : AbstractValidator<AddSubscribeRequest>
    {
        public AddSubscribeRequestValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User is required");
            RuleFor(x => x.AdvertisementId)
                .NotEmpty().WithMessage("Advertisement is required");
        }
    }
    public class AddSubscribeRequestProfile : Profile
    {
        public AddSubscribeRequestProfile()
        {
            CreateMap<AddSubscribeRequest, AddSubscribeModel>();
        }
    }
}
