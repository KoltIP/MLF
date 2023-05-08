using AutoMapper;
using PetProject.AdvertisementServices.Models.File;

namespace PetProject.Api.Controllers.Advertisement.Models.File
{
    public class FileResponse
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }

    public class FileResponseProfile : Profile
    {
        public FileResponseProfile()
        {
            CreateMap<FileResponseModel, FileResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AdvertisementId, opt => opt.MapFrom(src => src.AdvertisementId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType));
        }
    }
}
