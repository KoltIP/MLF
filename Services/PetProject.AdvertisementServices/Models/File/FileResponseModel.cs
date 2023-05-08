using AutoMapper;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.AdvertisementServices.Models.File
{
    public class FileResponseModel
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }

    public class FileResponseModelProfile : Profile
    {
        public FileResponseModelProfile()
        {
            CreateMap<PetFile, FileResponseModel>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => Convert.FromBase64String(src.Content)));
        }
    }

}
