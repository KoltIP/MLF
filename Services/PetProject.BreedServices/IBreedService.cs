using PetProject.BreedServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.BreedServices
{
    public interface IBreedService
    {
        Task<IEnumerable<BreedModel>> GetBreeds(int offset = 0, int limit = 10);
        Task<BreedModel> GetBreed(int id);
        Task<BreedModel> AddBreed(AddBreedModel model);
        Task EditBreed(int id, EditBreedModel model);
        Task DeleteBreed(int id);
    }
}
