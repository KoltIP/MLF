using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetProject.Db.Context.Context;
using PetProject.Db.Entities;
using PetProject.PetServices.Models;
using PetProject.Shared.Common.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.PetServices
{
    public class PetService : IPetService
    {
        private readonly IMapper mapper;
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IModelValidator<AddPetModel> addPetModelValidator;
        private readonly IModelValidator<EditPetModel> editPetModelValidator;

        public PetService(IMapper mapper,
            IDbContextFactory<MainDbContext> contextFactory,
             IModelValidator<AddPetModel> addPetModelValidator,
             IModelValidator<EditPetModel> editPetModelValidator)
        { 
            this.mapper = mapper;
            this.contextFactory = contextFactory;
            this.addPetModelValidator = addPetModelValidator;
            this.editPetModelValidator = editPetModelValidator;
        }

        public async Task<IEnumerable<PetModel>> GetPets(int offset = 0, int limit = 10)
        {
            var context = contextFactory.CreateDbContext();
            var pets = context.Pets.AsQueryable();

            pets = pets
                        .Skip(Math.Max(offset, 0))
                        .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await pets.ToListAsync()).Select(pet => mapper.Map<PetModel>(pet));
            return data;
        }


        public async Task<PetModel> GetPet(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var pet = context.Pets.FirstOrDefault(x => x.Id.Equals(id));

            var data = mapper.Map<PetModel>(pet);
            return data;
        }


        public async Task<PetModel> AddPet(AddPetModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var pet = mapper.Map<Pet>(model);

            await context.Pets.AddAsync(pet);

            context.SaveChanges(); 

            return mapper.Map<PetModel>(pet); 
        }


        public async Task EditPet(int id, EditPetModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var pet = await context.Pets.FirstOrDefaultAsync(x => x.Id.Equals(id));

            pet = mapper.Map(model, pet);

            context.Pets.Update(pet);

            context.SaveChanges();
        }


        public async Task DeletePet(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var pet = context.Pets.FirstOrDefault(x => x.Id == id);

            context.Pets.Remove(pet);

            context.SaveChanges();
        }


    }
}
