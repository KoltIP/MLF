﻿using AutoMapper;
using PetProject.AdvertisementServices.Models.File;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.AdvertisementServices.Models.Advertisement
{
    public class AdvertisementModel
    {
        public int Id { get; set; }
        public bool Gender { get; set; }
        public bool IsWanted { get; set; }
        public Guid UserId { get; set; }
        public int PetId { get; set; }
        public string? PetName { get; set; } = string.Empty;
        public string? PetDescription { get; set; } = string.Empty;
        public float? Price { get; set; }
        public int PetColorId { get; set; }
        public string PetColor { get; set; } = string.Empty;
        public int PetBreedId { get; set; }
        public string PetBreed { get; set; } = string.Empty;
        public int PetTypeId { get; set; }
        public string PetType { get; set; } = string.Empty;
        public int CityId { get; set; }
        public string City { get; set; } = string.Empty;
        public int ImageId { get; set; }
        public int? Age { get; set; }
        public DateTime? DateLost { get; set; }
        public List<FileResponseModel> Images { get; set; } = new List<FileResponseModel>();

    }

    public class AdvertisementModelProfile : Profile
    {
        public AdvertisementModelProfile()
        {
            CreateMap<PetProject.Db.Entities.Advertisement, AdvertisementModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.PetName))
                .ForMember(dest => dest.PetDescription, opt => opt.MapFrom(src => src.PetDescription))
                .ForMember(dest => dest.PetColor, opt => opt.MapFrom(src => src.Color.Name))
                .ForMember(dest => dest.PetBreed, opt => opt.MapFrom(src => src.Type.Breed.Name))
                .ForMember(dest => dest.PetType, opt => opt.MapFrom(src => src.Type.Name))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name));
        }
    }
}
