using PetProject.ColorServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.ColorServices
{
    public interface IColorService
    {
        Task<IEnumerable<ColorModel>> GetColors(int offset = 0, int limit = 10);
        Task<ColorModel> GetColor(int id);
        Task<ColorModel> AddColor(AddColorModel model);
        Task EditColor(int id, EditColorModel model);
        Task DeleteColor(int id);
    }
}
