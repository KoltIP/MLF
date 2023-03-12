using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetProject.Db.Context.Context;
using PetProject.Db.Entities;
using PetProject.Shared.Common.Validator;
using PetProject.TypeServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.TypeServices
{
    public class TypeService : ITypeService
    {
        private readonly IMapper mapper;
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IModelValidator<AddTypeModel> addTypeModelValidator;
        private readonly IModelValidator<EditTypeModel> editTypeModelValidator;

        public TypeService(IMapper mapper,
            IDbContextFactory<MainDbContext> contextFactory,
             IModelValidator<AddTypeModel> addTypeModelValidator,
             IModelValidator<EditTypeModel> editTypeModelValidator)
        {
            this.mapper = mapper;
            this.contextFactory = contextFactory;
            this.addTypeModelValidator = addTypeModelValidator;
            this.editTypeModelValidator = editTypeModelValidator;
        }

        public async Task<IEnumerable<TypeModel>> GetTypes(int offset = 0, int limit = 10)
        {
            var context = contextFactory.CreateDbContext();
            var types = context.PetTypies
                .Include(x=>x.Breed)
                .AsQueryable();

            types = types
                        .Skip(Math.Max(offset, 0))
                        .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await types.ToListAsync()).Select(type => mapper.Map<TypeModel>(type));
            return data;
        }


        public async Task<TypeModel> GetType(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var type = context.PetTypies.Include(x => x.Breed).FirstOrDefault(x => x.Id.Equals(id));

            var data = mapper.Map<TypeModel>(type);
            return data;
        }


        public async Task<TypeModel> AddType(AddTypeModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var type = mapper.Map<PetType>(model);

            await context.PetTypies.AddAsync(type);

            context.SaveChanges();

            return mapper.Map<TypeModel>(type);
        }


        public async Task EditType(int id, EditTypeModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var type = await context.PetTypies.FirstOrDefaultAsync(x => x.Id.Equals(id));

            type = mapper.Map(model, type);

            context.PetTypies.Update(type);

            context.SaveChanges();
        }


        public async Task DeleteType(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var type = context.PetTypies.FirstOrDefault(x => x.Id == id);

            context.PetTypies.Remove(type);

            context.SaveChanges();
        }


    }
}
