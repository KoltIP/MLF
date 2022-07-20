using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetProject.ColorServices.Models;
using PetProject.Db.Context.Context;
using PetProject.Db.Entities;
using PetProject.Shared.Common.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.ColorServices
{
    public class ColorService : IColorService
    {
        private readonly IMapper mapper;
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IModelValidator<AddColorModel> addColorModelValidator;
        private readonly IModelValidator<EditColorModel> editColorModelValidator;

        public ColorService(IMapper mapper,
            IDbContextFactory<MainDbContext> contextFactory,
             IModelValidator<AddColorModel> addColorModelValidator,
             IModelValidator<EditColorModel> editColorModelValidator)
        {
            this.mapper = mapper;
            this.contextFactory = contextFactory;
            this.addColorModelValidator = addColorModelValidator;
            this.editColorModelValidator = editColorModelValidator;
        }

        public async Task<IEnumerable<ColorModel>> GetColors(int offset = 0, int limit = 10)
        {
            var context = contextFactory.CreateDbContext();
            var colors = context.Colors.AsQueryable();

            colors = colors
                        .Skip(Math.Max(offset, 0))
                        .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await colors.ToListAsync()).Select(color => mapper.Map<ColorModel>(color));
            return data;
        }


        public async Task<ColorModel> GetColor(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var color = context.Colors.FirstOrDefault(x=>x.Id.Equals(id));

            var data = mapper.Map<ColorModel>(color);
            return data;
        }


        public async Task<ColorModel> AddColor(AddColorModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var color = mapper.Map<Color>(model);

            await context.Colors.AddAsync(color);

            context.SaveChanges();

            return mapper.Map<ColorModel>(color);
        }


        public async Task EditColor(int id, EditColorModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var color = await context.Colors.FirstOrDefaultAsync(x => x.Id.Equals(id));

            color = mapper.Map(model,color);

            context.Colors.Update(color);

            context.SaveChanges();
        }


        public async Task DeleteColor(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var color = context.Colors.FirstOrDefault(x => x.Id == id);

            context.Colors.Remove(color);

            context.SaveChanges();
        }
    }
}
