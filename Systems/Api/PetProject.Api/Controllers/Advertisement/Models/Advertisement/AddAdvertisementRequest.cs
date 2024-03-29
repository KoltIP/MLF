﻿using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;
using PetProject.AdvertisementServices.Models.Advertisement;
using PetProject.AdvertisementServices.Models.File;

namespace PetProject.Api.Controllers.Advertisement.Models.Advertisement
{
    public class AddAdvertisementRequest
    {
        public Guid UserId { get; set; }
        public int Gender { get; set; }
        public int IsWanted { get; set; }
        public string? PetName { get; set; }
        public string? PetDescription { get; set; }
        public float? Price { get; set; }
        public int PetColorId { get; set; }
        public int PetTypeId { get; set; }
        public int CityId { get; set; }
        public int? Age { get; set; }
        public DateTime? DateLost { get; set; }
        public List<AddFileModel> Images { get; set; }
    }

    public class addadvertismentrequestvalidator : AbstractValidator<AddAdvertisementRequest>
    {
        public addadvertismentrequestvalidator()
        {
            //RuleFor(x => x.UserId)
            //    .NotEmpty().WithMessage("error in api, userID is required");           
            //RuleFor(x => x.PetName)
            //    .NotEmpty().WithMessage("error in api, PetName is required");
            //RuleFor(x => x.PetDescription)
            //    .NotEmpty().WithMessage("error in api, PetDescription is required");
            //RuleFor(x => x.Price)
            //    .NotEmpty().WithMessage("error in api, Price is required");
            //RuleFor(x => x.PetColorId)
            //    .NotEmpty().WithMessage("error in api, PetColorId is required");
            //RuleFor(x => x.PetTypeId)
            //    .NotEmpty().WithMessage("error in api, PetTypeId  is required");
        }
    }
    public class AddAdvertismentRequestProfile : Profile
    {
        public AddAdvertismentRequestProfile()
        {
            CreateMap<AddAdvertisementRequest, AddAdvertisementModel>()
                 .ForMember(dest => dest.IsWanted, opt => opt.MapFrom(src => src.IsWanted == 1 ? true : false));
        }
    }
}
