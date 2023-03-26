using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetProject.Db.Context.Context;
using PetProject.LocationService.Models.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly IMapper mapper;
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public LocationService(IMapper mapper,
            IDbContextFactory<MainDbContext> contextFactory)
        {
            this.mapper = mapper;
            this.contextFactory = contextFactory;
        }

        public async Task<IEnumerable<CityModel>> GetCitiesAsync()
        {
            var context = contextFactory.CreateDbContext();
            var cities = context.Cities.AsQueryable();

            var data = await cities.Select(city => mapper.Map<CityModel>(city)).ToListAsync();
            return data;
        }
    }
}
