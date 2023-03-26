using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PetProject.AdvertisementServices.Models;
using PetProject.Db.Context.Context;
using PetProject.Db.Entities;
using PetProject.Shared.Common.Exceptions;
using PetProject.Shared.Common.Validator;
using PetProject.SubscribeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.SubscribeService
{
    public class SubscribeService : ISubscribeService
    {

        private readonly IMapper mapper;
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public SubscribeService(IMapper mapper,
            IDbContextFactory<MainDbContext> contextFactory)
        {
            this.mapper = mapper;
            this.contextFactory = contextFactory;
        }

        public async Task<IEnumerable<AdvertisementModel>> GetAllSubscribe(Guid UserId)
        {
            var context = contextFactory.CreateDbContext();
            var advertisements = context.Advertisements.AsQueryable();

            var subscribe = context.Subscriptions.AsQueryable().Where(x => x.UserId == UserId).Select(x => x.AdvertisementId).ToList();

            advertisements = advertisements.Where(x => subscribe.Contains(x.Id))
                        .Include(x => x.Color)
                        .Include(x => x.Type.Breed)
                        .Include(x => x.Type);

            var data = (await advertisements.ToListAsync()).Select(advertisement => mapper.Map<AdvertisementModel>(advertisement));
            return data;
        }


        public async Task AddSubscribe(AddSubscribeModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var find_sub = context.Subscriptions.FirstOrDefaultAsync(x => x.UserId == model.UserId && x.AdvertisementId == model.AdvertisementId);
            if (find_sub.Result != null)
            {
                throw new ProcessException("The subscription has already been issued.");
            }

            var sub = mapper.Map<Subscription>(model);
            await context.Subscriptions.AddAsync(sub);
            context.SaveChanges();
        }


        public async Task DeleteSubscribe(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var find_sub = context.Subscriptions.FirstOrDefault(x => x.Id == id);
            if (find_sub != null)
            {
                throw new ProcessException("The subscription hasn't find.");
            }
            context.Subscriptions.Remove(find_sub);
            context.SaveChanges();
        }
    }
}
