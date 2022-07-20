using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetProject.Db.Context.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Db.Context.Setup
{
    public static class DbSeed
    {
        private static void AddData(MainDbContext context)
        {
            if (context.Breeds.Any() || context.Colors.Any() || context.PetTypies.Any())
                return;

            var breed1 = new Entities.Breed()
            {
                Name = "Не указано",
                Id = 1
            };
            context.Breeds.Add(breed1);

            var color1 = new Entities.Color()
            {
                Id = 1,
                Name = "Не указано"
            };
            context.Colors.Add(color1);


            var petType1 = new Entities.PetType()
            {
                Id = 1,
                Name = "Не указано",
                Description = "Не указано",
                BreedId = 1
            };
            context.PetTypies.Add(petType1);

            context.SaveChanges();
        }

        public static void Execute(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();
            ArgumentNullException.ThrowIfNull(scope);

            var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>();
            using var context = factory.CreateDbContext();

            AddData(context);
        }
    }
}
