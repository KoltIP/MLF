using AutoMapper;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.LocationService.Models.Cities
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class CityModelProfile : Profile
    {
        public CityModelProfile()
        {
            CreateMap<City, CityModel>();
        }
    }

}
