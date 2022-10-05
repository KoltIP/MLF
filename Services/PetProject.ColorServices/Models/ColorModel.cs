using AutoMapper;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.ColorServices.Models
{
    public class ColorModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class ColorModelProfile : Profile
    {
        public ColorModelProfile()
        {
            CreateMap<Color, ColorModel>();
        }
    }
}
