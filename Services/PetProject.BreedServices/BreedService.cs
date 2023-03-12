using AutoMapper;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using PetProject.BreedServices.Models;
using PetProject.Db.Context.Context;
using PetProject.Db.Entities;
using PetProject.Shared.Common.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.BreedServices
{
    public class BreedService : IBreedService
    {
        private readonly IMapper mapper;
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IModelValidator<AddBreedModel> addBreedModelValidator;
        private readonly IModelValidator<EditBreedModel> editBreedModelValidator;

        public BreedService(IMapper mapper,
            IDbContextFactory<MainDbContext> contextFactory,
             IModelValidator<AddBreedModel> addBreedModelValidator,
             IModelValidator<EditBreedModel> editBreedModelValidator)
        {
            this.mapper = mapper;
            this.contextFactory = contextFactory;
            this.addBreedModelValidator = addBreedModelValidator;
            this.editBreedModelValidator = editBreedModelValidator;
        }

        public async Task<IEnumerable<BreedModel>> GetBreedsWithTypeId(int typeId, int offset = 0, int limit = 10)
        {
            var context = contextFactory.CreateDbContext();

            var breedIds = context.PetTypies.Where(x => x.Id == typeId).AsQueryable().Select(x=>x.BreedId).ToList();

            var breeds = context.Breeds.Where(x=>breedIds.Contains(x.Id));

            breeds = breeds                
                        .Skip(Math.Max(offset, 0))
                        .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await breeds.ToListAsync()).Select(breed => mapper.Map<BreedModel>(breed));
            return data;
        }

        public async Task<IEnumerable<BreedModel>> GetBreeds(int offset = 0, int limit = 10)
        {
            var context = contextFactory.CreateDbContext();
            var breeds = context.Breeds.AsQueryable();

            breeds = breeds
                        .Skip(Math.Max(offset, 0))
                        .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await breeds.ToListAsync()).Select(breed => mapper.Map<BreedModel>(breed));
            return data;
        }


        public async Task<BreedModel> GetBreed(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var breed = context.Breeds.FirstOrDefault(x => x.Id.Equals(id));

            var data = mapper.Map<BreedModel>(breed);
            return data;
        }


        public async Task<BreedModel> AddBreed(AddBreedModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var breed = mapper.Map<Breed>(model);

            await context.Breeds.AddAsync(breed);

            context.SaveChanges();

            return mapper.Map<BreedModel>(breed);
        }


        public async Task EditBreed(int id, EditBreedModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var breed = await context.Breeds.FirstOrDefaultAsync(x => x.Id.Equals(id));

            breed = mapper.Map(model, breed);

            context.Breeds.Update(breed);

            context.SaveChanges();
        }


        public async Task DeleteBreed(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var breed = context.Breeds.FirstOrDefault(x => x.Id == id);

            context.Breeds.Remove(breed);

            context.SaveChanges();
        }
    }
}
