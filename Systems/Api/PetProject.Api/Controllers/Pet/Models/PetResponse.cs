using AutoMapper;
using PetProject.PetServices.Models;

namespace PetProject.Api.Controllers.Pet.Models
{
    public class PetResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ColorId { get; set; }
        public string Color { get; set; } = string.Empty;
        public int TypeId { get; set; }
        public string Type { get; set; } = string.Empty;
        public int BreedId { get; set; }
        public string Breed { get; set; } = string.Empty;
    }

    public class PetResponseProfile : Profile
    {
        public PetResponseProfile()
        {
            CreateMap<PetModel, PetResponse>();
        }
    }
}
