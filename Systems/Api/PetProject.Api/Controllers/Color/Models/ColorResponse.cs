using AutoMapper;
using PetProject.ColorServices.Models;

namespace PetProject.Api.Controllers.Color.Models
{
    public class ColorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class ColorResponseProfile : Profile
    {
        public ColorResponseProfile()
        {
            CreateMap<ColorModel, ColorResponse>();
        }
    }
}
