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
        public int Id { get; set; }
        public bool IsWanted { get; set; }
        public Guid UserId { get; set; }
        public string? PetName { get; set; } = string.Empty;
        public string? PetDescription { get; set; } = string.Empty;
        public float? Price { get; set; }
        public int PetColorId { get; set; }
        public int PetTypeId { get; set; }
        public int CityId { get; set; }
        public int? Age { get; set; }
        public DateTime? DateLost { get; set; }
    }

    public class EditAdvertisementResponseValidator : AbstractValidator<EditAdvertisementModel>
    {
        public EditAdvertisementResponseValidator()
        {
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
