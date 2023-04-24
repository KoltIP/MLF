﻿using PetProject.AdvertisementServices.Models;
using PetProject.FilterService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.AdvertisementServices
{
    public interface IAdvertisementService
    {
        Task<IEnumerable<AdvertisementModel>> GetAdvertisements();
        Task<AdvertisementModel> GetAdvertisement(int id);
        Task<AdvertisementModel> AddAdvertisement(AddAdvertisementModel model);
        Task EditAdvertisement(int id, EditAdvertisementModel model);
        Task DeleteAdvertisement(int id);
        Task<IEnumerable<AdvertisementModel>> FilterAdvertisement(FilterModel filter);
    }
}
