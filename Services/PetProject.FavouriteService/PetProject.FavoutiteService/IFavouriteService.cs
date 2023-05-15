
using PetProject.AdvertisementServices.Models.Advertisement;
using PetProject.FavoutiteService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FavoutiteService
{
    public interface IFavouriteService
    {
        Task<AdvertisementsModelList> GetAllFavourite(Guid UserId, int pageNumber);
        Task AddInFavourite(AddFavouriteModel model);
        Task DeleteInFavourite(int id);
    }
}
