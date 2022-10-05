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
                Id = 1,
                Name = "Не указано",
                Description = "Не указано"
            };
            context.Breeds.Add(breed1);

            var color1 = new Entities.Color()
            {
                Id = 1,
                Name = "Не указано",
                Description = "Не указано"
            };
            context.Colors.Add(color1);


            var petType1 = new Entities.PetType()
            {
                Id = 1,
                Name = "Не указано",
                Description = "Не указано"
            };
            context.PetTypies.Add(petType1);

            var pet1 = new Entities.Pet()
            {
                Id = 1,
                Name = "Не указано",
                Description = "Не указано",
                ColorId = color1.Id,
                Color = color1,
                BreedId = breed1.Id,
                Breed = breed1,
                PetTypeId = petType1.Id,
                Type = petType1,
            };
            context.Pets.Add(pet1);

            //var user1 = new Entities.User.User()
            //{
            //    Id = Guid.NewGuid(),
            //    NickName = "Не указано",
            //    Email = "notFond@gmail.com",
            //    Name = "Не указано",
            //    Surname = "Не указано",
            //    Patronymic = "Не указано",
            //    Age = 99,
            //    Specialization = "Не указано",
            //    EmailConfirmed = false,
            //    NormalizedEmail = "notFond@gmail.com".ToUpper(),
            //    PasswordHash = "123456789",
            //};
            //context.Users.Add(user1);

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
