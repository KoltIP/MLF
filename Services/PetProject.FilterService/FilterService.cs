using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetProject.Db.Context.Context;
using PetProject.Db.Entities;
using PetProject.FilterService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FilterService
{
    public class FilterService : IFilterService
    {
        private readonly IMapper mapper;
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public FilterService(IMapper mapper,
            IDbContextFactory<MainDbContext> contextFactory)
        {
            this.mapper = mapper;
            this.contextFactory = contextFactory;
        }

        public async Task<FilterModel> GetFilter(Guid userGuid)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var filter = context.AdvertisementFilter.FirstOrDefault(x => x.UserId == userGuid);
            var filterModel = mapper.Map<FilterModel>(filter);
            return filterModel;
        }

        public async Task AddOrEditFilter(FilterModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var oldFilter = context.AdvertisementFilter.FirstOrDefault(x => x.UserId == model.UserId);
            if (oldFilter != null)
            {
                var updatedFilter = mapper.Map(model, oldFilter);
                context.AdvertisementFilter.Update(updatedFilter);
                context.SaveChanges();
            }
            else
            {
                var newFilter = mapper.Map<AdvertisementFilter>(model);
                await context.AdvertisementFilter.AddAsync(newFilter);
                context.SaveChanges();
            }
        }        

        public async Task DeleteFilter(Guid userGuid)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var filter = context.AdvertisementFilter.FirstOrDefault(x => x.UserId == userGuid);
            if (filter != null)
            {
                var result = context.AdvertisementFilter.Remove(filter);
                if (result!= null)
                    context.SaveChanges();
            }
        }
    }
}
