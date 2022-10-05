using AutoMapper;
using PetProject.BreedServices.Models;

namespace PetProject.Api.Controllers.Breed.Models
{
    public class BreedResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class BreedResponseProfile : Profile
    {
        public BreedResponseProfile()
        {
            CreateMap<BreedModel, BreedResponse>();
        }
    }
}
