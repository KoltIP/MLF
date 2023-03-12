using AutoMapper;
using FluentValidation;
using PetProject.AdvertisementServices.Models;

namespace PetProject.Api.Controllers.Advertisement.Models
{
    public class AddAdvertisementRequest
    {
        public Guid UserId { get; set; }
        public string PetName { get; set; } 
        public string PetDescription { get; set; } 
        public float Price { get; set; }
        public int PetColorId { get; set; }
        public int PetTypeId { get; set; }
        //public Importance Importance { get; set; }
        //public DateTime Age { get; set; }
        //public DateTime CreatedDate { get; set; }
    }

    public class addadvertismentrequestvalidator : AbstractValidator<AddAdvertisementRequest>
    {
        public addadvertismentrequestvalidator()
        {          
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("error in api, userID is required");           
            RuleFor(x => x.PetName)
                .NotEmpty().WithMessage("error in api, PetName is required");
            RuleFor(x => x.PetDescription)
                .NotEmpty().WithMessage("error in api, PetDescription is required");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("error in api, Price is required");
            RuleFor(x => x.PetColorId)
                .NotEmpty().WithMessage("error in api, PetColorId is required");
            RuleFor(x => x.PetTypeId)
                .NotEmpty().WithMessage("error in api, PetTypeId  is required");
        }
    }
    public class AddAdvertismentRequestProfile : Profile
    {
        public AddAdvertismentRequestProfile()
        {
            CreateMap<AddAdvertisementRequest, AddAdvertisementModel>();
        }
    }
}
