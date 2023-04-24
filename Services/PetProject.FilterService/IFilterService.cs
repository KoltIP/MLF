using PetProject.FilterService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FilterService
{
    public interface IFilterService
    {
        Task<FilterModel> GetFilter(Guid userGuid);
        Task AddOrEditFilter(FilterModel model);
        Task DeleteFilter(Guid userGuid);
    }
}
