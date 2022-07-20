using AutoMapper;
using FluentValidation;
using PetProject.AdvertisementServices.Models;

namespace PetProject.Api.Controllers.Advertisement.Models
{
    public class EditAdvertisementRequest
    {
        public Guid UserId { get; set; }
        public float Price { get; set; }
        public int PetId { get; set; }
    }

    public class EditAdvertismentRequestValidator : AbstractValidator<EditAdvertisementRequest>
    {
        public EditAdvertismentRequestValidator()
        {
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User is required");
            RuleFor(x => x.PetId)
                .NotEmpty().WithMessage("Pet id is required");
        }
    }
    public class EditAdvertismentRequestProfile : Profile
    {
        public EditAdvertismentRequestProfile()
        {
            CreateMap<EditAdvertisementRequest, EditAdvertisementModel>();
        }
    }
}
