using PetProject.TypeServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.TypeServices
{
    public interface ITypeService
    {
        Task<IEnumerable<TypeModel>> GetTypes(int offset = 0, int limit = 10);
        Task<TypeModel> GetType(int id);
        Task<TypeModel> AddType(AddTypeModel model);
        Task EditType(int id, EditTypeModel model);
        Task DeleteType(int id);
    }
}
