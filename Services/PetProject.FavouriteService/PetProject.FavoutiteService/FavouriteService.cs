using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PetProject.AdvertisementServices.Models.Advertisement;
using PetProject.Db.Context.Context;
using PetProject.Db.Entities;
using PetProject.FavoutiteService.Models;
using PetProject.Shared.Common.Exceptions;
using PetProject.Shared.Common.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.FavoutiteService
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IMapper mapper;
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public FavouriteService(IMapper mapper,
            IDbContextFactory<MainDbContext> contextFactory)
        {
            this.mapper = mapper;
            this.contextFactory = contextFactory;
        }

        public async Task<IEnumerable<AdvertisementModel>> GetAllFavourite(Guid UserId)
        {
            var context = contextFactory.CreateDbContext();
            var advertisements = context.Advertisements.AsQueryable();

            var favourites = context.Favourites.AsQueryable().Where(x => x.UserId == UserId).Select(x => x.AdvertisementId).ToList();

            advertisements = advertisements.Where(x => favourites.Contains(x.Id))
                        .Include(x => x.Color)
                        .Include(x => x.Type.Breed)
                        .Include(x => x.Type);

            var data = (await advertisements.ToListAsync()).Select(advertisement => mapper.Map<AdvertisementModel>(advertisement));
            return data;
        }

        public async Task AddInFavourite(AddFavouriteModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var find_fav = context.Favourites.FirstOrDefaultAsync(x => x.UserId == model.UserId && x.AdvertisementId == model.AdvertisementId);
            if (find_fav.Result != null)
            {
                throw new ProcessException("The favourite has already been issued.");
            }

            var fav = mapper.Map<Favourite>(model);
            await context.Favourites.AddAsync(fav);
            context.SaveChanges();
        }


        public async Task DeleteInFavourite(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var find_fav = context.Favourites.FirstOrDefault(x => x.Id == id);
            if (find_fav != null)
            {
                throw new ProcessException("The favourites hasn't find.");
            }
            context.Favourites.Remove(find_fav);
            context.SaveChanges();
        }
    }
}
