using AutoMapper;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.AdvertisementServices.Models
{
    public class AdvertisementModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public float Price { get; set; }
        //public Importance Importance { get; set; }
        public int PetId { get; set; }
    }

    public class AdvertisementModelProfile : Profile
    {
        public AdvertisementModelProfile()
        {
            CreateMap<Advertisement, AdvertisementModel>();
        }
    }
}
