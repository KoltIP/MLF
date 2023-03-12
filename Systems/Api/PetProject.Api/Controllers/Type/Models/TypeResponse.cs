using AutoMapper;
using PetProject.TypeServices.Models;

namespace PetProject.Api.Controllers.Type.Models
{
    public class TypeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int BreedId { get; set; }
        public string BreedName { get; set; }
    }

    public class TypeResponseProfile : Profile
    {
        public TypeResponseProfile()
        {
            CreateMap<TypeModel, TypeResponse>();
        }
    }
}
