﻿using PetProject.AdvertisementServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.AdvertisementServices
{
    public interface IAdvertisementService
    {
        Task<IEnumerable<AdvertisementModel>> GetAdvertisements(int offset = 0, int limit = 10);
        Task<AdvertisementModel> GetAdvertisement(int id);
        Task<AdvertisementModel> AddAdvertisement(AddAdvertisementModel model);
        Task EditAdvertisement(int id, EditAdvertisementModel model);
        Task DeleteAdvertisement(int id);
        Task AddSubscribe(AddSubscribeModel model);
    }
}
