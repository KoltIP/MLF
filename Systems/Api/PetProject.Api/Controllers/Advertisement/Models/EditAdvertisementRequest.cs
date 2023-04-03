using AutoMapper;
using FluentValidation;
using PetProject.AdvertisementServices.Models;

namespace PetProject.Api.Controllers.Advertisement.Models
{
    public class EditAdvertisementRequest
    {
        public Guid UserId { get; set; }
        public string? PetName { get; set; } = string.Empty;
        public string? PetDescription { get; set; } = string.Empty;
        public bool IsWanted { get; set; }
        public float? Price { get; set; }
        public int PetColorId { get; set; }
        public int PetTypeId { get; set; }
        public int CityId { get; set; }
        public int? Age { get; set; }
        public DateTime? DateLost { get; set; }
    }

    public class EditAdvertismentRequestValidator : AbstractValidator<EditAdvertisementRequest>
    {
        public EditAdvertismentRequestValidator()
        {
            //RuleFor(x => x.Price)
            //    .NotEmpty().WithMessage("Price is required");
            //RuleFor(x => x.UserId)
            //    .NotEmpty().WithMessage("User is required");
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
