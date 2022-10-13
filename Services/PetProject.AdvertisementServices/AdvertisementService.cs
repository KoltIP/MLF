using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetProject.AdvertisementServices.Models;
using PetProject.Db.Context.Context;
using PetProject.Db.Entities;
using PetProject.Shared.Common.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.AdvertisementServices
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IMapper mapper;
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IModelValidator<AddAdvertisementModel> addAdvertisementModelValidator;
        private readonly IModelValidator<EditAdvertisementModel> editAdvertisementModelValidator;

        public AdvertisementService(IMapper mapper,
            IDbContextFactory<MainDbContext> contextFactory,
             IModelValidator<AddAdvertisementModel> addAdvertisementModelValidator,
             IModelValidator<EditAdvertisementModel> editAdvertisementModelValidator)
        {
            this.mapper = mapper;
            this.contextFactory = contextFactory;
            this.addAdvertisementModelValidator = addAdvertisementModelValidator;
            this.editAdvertisementModelValidator = editAdvertisementModelValidator;
        }

        public async Task<IEnumerable<AdvertisementModel>> GetAdvertisements(int offset = 0, int limit = 10)
        {
            var context = contextFactory.CreateDbContext();
            var advertisements = context.Advertisements.AsQueryable();

            advertisements = advertisements
                        .Include(x => x.Color)
                        .Include(x => x.Breed)
                        .Include(x => x.Type)
                        .Skip(Math.Max(offset, 0))
                        .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await advertisements.ToListAsync()).Select(advertisement => mapper.Map<AdvertisementModel>(advertisement));
            return data;
        }


        public async Task<AdvertisementModel> GetAdvertisement(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var advertisement = context.Advertisements
                .Include(x => x.Color)
                .Include(x => x.Breed)
                .Include(x => x.Type)
                .FirstOrDefault(x => x.Id.Equals(id));

            var data = mapper.Map<AdvertisementModel>(advertisement);
            return data;
        }


        public async Task<AdvertisementModel> AddAdvertisement(AddAdvertisementModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var advertisement = mapper.Map<Advertisement>(model);

            await context.Advertisements.AddAsync(advertisement);          

            context.SaveChanges();

            return mapper.Map<AdvertisementModel>(advertisement);
        }


        public async Task EditAdvertisement(int id, EditAdvertisementModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var advertisement = await context.Advertisements.FirstOrDefaultAsync(x => x.Id.Equals(id));

            advertisement = mapper.Map(model, advertisement);

            context.Advertisements.Update(advertisement);

            context.SaveChanges();
        }


        public async Task DeleteAdvertisement(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var advertisement = context.Advertisements.FirstOrDefault(x => x.Id == id);

            context.Advertisements.Remove(advertisement);

            context.SaveChanges();
        }
    }
}
