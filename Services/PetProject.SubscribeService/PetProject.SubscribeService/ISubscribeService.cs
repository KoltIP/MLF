using PetProject.AdvertisementServices.Models.Advertisement;
using PetProject.SubscribeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.SubscribeService
{
    public interface ISubscribeService
    {
        Task<IEnumerable<AdvertisementModel>> GetAllSubscribe(Guid UserId);
        Task AddSubscribe(AddSubscribeModel model);
        Task DeleteSubscribe(int id);
    }
}
