using PetProject.PetServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.PetServices
{
    public interface IPetService
    {
        Task<IEnumerable<PetModel>> GetPets(int offset = 0, int limit = 10);
        Task<PetModel> GetPet(int id);
        Task<PetModel> AddPet(AddPetModel model);
        Task EditPet(int id, EditPetModel model);
        Task DeletePet(int id);
    }
}
