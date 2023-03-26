using PetProject.LocationService.Models.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.LocationService
{
    public interface ILocationService
    {
        public Task<IEnumerable<CityModel>> GetCitiesAsync();
    }
}
