﻿using PetProject.AdvertisementServices.Models;
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
        Task<IEnumerable<AdvertisementModel>> GetAllFavourite(Guid UserId);
        Task AddInFavourite(AddFavouriteModel model);
        Task DeleteInFavourite(int id);
    }
}