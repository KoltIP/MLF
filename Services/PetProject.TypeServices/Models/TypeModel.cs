using AutoMapper;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.TypeServices.Models
{
    public class TypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int BreedId { get; set; }
        public string BreedName { get; set;} = string.Empty;
    }

    public class TypeModelProfile : Profile
    {
        public TypeModelProfile()
        {
            CreateMap<PetType, TypeModel>();
        }
    }
}
