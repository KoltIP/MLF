using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.EntityFrameworkCore;
using PetProject.AdvertisementServices.Models;
using PetProject.Db.Context.Context;
using PetProject.Db.Entities;
using PetProject.FilterService;
using PetProject.FilterService.Models;
using PetProject.Shared.Common.Exceptions;
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

        public async Task<IEnumerable<AdvertisementModel>> GetAdvertisements()
        {
            var context = contextFactory.CreateDbContext();                                    
            var advertisements = context.Advertisements.AsQueryable();
            advertisements = advertisements
                        .Include(x => x.Color)
                        .Include(x => x.Type.Breed)
                        .Include(x => x.Type)
                        .Include(x => x.City);
            //.Include(x => x.PetImages);           

            var data = (await advertisements.ToListAsync()).Select(advertisement => mapper.Map<AdvertisementModel>(advertisement)).ToList();

            for (int i = 0; i < data.Count(); i++)
            {
                var files = context.PetFiles.AsQueryable().Where(x => x.AdvertisementId == data[i].Id);
                data[i].Images = files.Select(file => mapper.Map<FileResponseModel>(file)).ToList();
            }

            return data;
        }

        public async Task<AdvertisementModel> GetAdvertisement(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var advertisement = context.Advertisements
                .Include(x => x.Color)
                .Include(x => x.Type.Breed)
                .Include(x => x.Type)
                .Include(x => x.City)
                .FirstOrDefault(x => x.Id.Equals(id));

            var data = mapper.Map<AdvertisementModel>(advertisement);
            return data;
        }

        public async Task<AdvertisementModel> AddAdvertisement(AddAdvertisementModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var advertisement = mapper.Map<Advertisement>(model);

            advertisement.DateCreated = DateTime.Now;

            var advertisementResult = await context.Advertisements.AddAsync(advertisement);

            context.SaveChanges();

            for (int i = 0; i < model.Images.Count(); i++)                
            {
                var file = new PetFile()
                {
                    AdvertisementId = advertisement.Id,
                    Content = Convert.ToBase64String(model.Images[i].Content),
                    ContentType = model.Images[i].ContentType,  
                };
                var imageResult = await context.PetFiles.AddAsync(file);
            }
            

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

        public async Task<IEnumerable<AdvertisementModel>> FilterAdvertisement(FilterModel filter)
        {
            var context = contextFactory.CreateDbContext();          
            
            var advertisements = context.Advertisements.AsQueryable();

            advertisements = advertisements
                        .Include(x => x.Color)
                        .Include(x => x.Type.Breed)
                        .Include(x => x.Type)
                        .Include(x => x.City)
                        .Include(x => x.PetImages);

            //Добавить логику
            if (filter.Price.HasValue)
                advertisements = advertisements.Where(x => x.Price == filter.Price);
            if (filter.IsWanted.HasValue)
                advertisements = advertisements.Where(x => x.IsWanted == (filter.IsWanted.Value == 1 ? true:false));
            if (filter.Gender.HasValue)
                advertisements = advertisements.Where(x => x.Gender == (filter.Gender.Value == 1 ? true : false));
            if (filter.AgeStart.HasValue || filter.AgeEnd.HasValue)
            {
                if (filter.AgeStart.HasValue && filter.AgeEnd.HasValue)
                    advertisements = advertisements.Where(x => x.DateLost <= filter.DateLostEnd && x.DateLost >= filter.DateLostStart);
                else if (filter.AgeStart.HasValue)
                    advertisements = advertisements.Where(x => x.DateLost >= filter.DateLostStart);
                else
                    advertisements = advertisements.Where(x => x.DateLost <= filter.DateLostEnd);
            }
            if (filter.CityId.HasValue && filter.CityId.Value != 0)
                advertisements = advertisements.Where(x => x.CityId == filter.CityId);
            if (filter.PetColorId.HasValue && filter.PetColorId.Value != 0)
                advertisements = advertisements.Where(x => x.PetColorId == filter.PetColorId);
            if(filter.PetTypeId.HasValue && filter.PetTypeId.Value != 0)
                advertisements = advertisements.Where(x => x.PetTypeId == filter.PetTypeId);
            if (filter.PetBreedId.HasValue && filter.PetBreedId.Value != 0)
                advertisements = advertisements.Where(x => x.Type.BreedId == filter.PetBreedId);


            var data = (await advertisements.ToListAsync()).Select(advertisement => mapper.Map<AdvertisementModel>(advertisement));
            return data;
        }

        public async Task<FileResponseModel> GetFile()
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var fileEntity = context.PetFiles.First();

            var result = new FileResponseModel()
            {
                Id = fileEntity.Id,
                AdvertisementId = fileEntity.AdvertisementId,
                Content = Convert.FromBase64String(fileEntity.Content),
                ContentType = fileEntity.ContentType,
            };

            return result;
        }

        //public async Task<IEnumerable<FileResponseModel>> GetFiles()
        //{
        //    using var context = await contextFactory.CreateDbContextAsync();
        //    var filesEntities = context.PetFiles.ToList();

        //    var result = new List<FileResponseModel>();
        //    for (int i = 0; i < filesEntities.Count(); i++)
        //    {
        //        var item = new FileResponseModel()
        //        {
        //            Content = Convert.FromBase64String(filesEntities[i].Content),
        //            ContentType = filesEntities[i].ContentType,
        //        };
        //        result.Add(item);
        //    }

        //    return result;
        //}
    }
}
