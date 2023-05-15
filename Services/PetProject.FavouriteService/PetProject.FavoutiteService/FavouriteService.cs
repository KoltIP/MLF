using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetProject.AdvertisementServices.Models.Advertisement;
using PetProject.AdvertisementServices.Models.File;
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
        private const int countAdvOnpage = 12;
        private readonly IMapper mapper;
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public FavouriteService(IMapper mapper,
            IDbContextFactory<MainDbContext> contextFactory)
        {
            this.mapper = mapper;
            this.contextFactory = contextFactory;
        }

        public async Task<AdvertisementsModelList> GetAllFavourite(Guid UserId, int pageNumber)
        {
            var context = contextFactory.CreateDbContext();

            var favourites = context.Favourites.AsQueryable().Where(x => x.UserId == UserId).Select(x => x.AdvertisementId).ToList();
            
            var advertisements = context.Advertisements.AsQueryable()
                        .Include(x => x.Color)
                        .Include(x => x.Type.Breed)
                        .Include(x => x.Type)
                        .Include(x => x.City)
                        .Where(x => favourites.Contains(x.Id)); 

            var count = advertisements.Count();

            advertisements = advertisements.Skip(countAdvOnpage * (pageNumber - 1)).Take(countAdvOnpage);

            var data = advertisements.Select(advertisement => mapper.Map<AdvertisementModel>(advertisement)).ToList();
            for (int i = 0; i < data.Count(); i++)
            {
                var files = context.PetFiles.AsQueryable().Where(x => x.AdvertisementId == data[i].Id);
                data[i].Images = files.Select(file => mapper.Map<FileResponseModel>(file)).ToList();
            }

            AdvertisementsModelList advertisementsModelList = new AdvertisementsModelList()
            {
                Advertisements = data,
                Count = count
            };

            return advertisementsModelList;
        }

        public async Task AddInFavourite(AddFavouriteModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var find_fav = context.Favourites.FirstOrDefaultAsync(x => x.UserId == model.UserId && x.AdvertisementId == model.AdvertisementId);
            if (find_fav.Result != null)
            {
                throw new ProcessException("Такое объявление уже добавлено в избранное!");
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
                throw new ProcessException("Объявление не было найдено");
            }
            context.Favourites.Remove(find_fav);
            context.SaveChanges();
        }
    }
}
