﻿using Microsoft.EntityFrameworkCore;
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

            var breed2 = new Entities.Breed()
            {
                Id = 2,
                Name = "Вест-Айленд Вайт Терьер",
                Description = "Коротколапая ирландская порода собак исключительно белого цвета"
            };
            context.Breeds.Add(breed2);

            var breed3 = new Entities.Breed()
            {
                Id = 3,
                Name = "ЧихуаХуа",
                Description = "Мелкая мексиканская порода почти собак"
            };
            context.Breeds.Add(breed3);

            var breed4 = new Entities.Breed()
            {
                Id = 4,
                Name = "Немецка овчарка",
                Description = "Крупная и опасная собака"
            };
            context.Breeds.Add(breed4);

            var breed5 = new Entities.Breed()
            {
                Id = 5,
                Name = "Сиамский",
                Description = "Опасный и агрессивный"
            };
            context.Breeds.Add(breed5);

            context.SaveChanges();

            var color1 = new Entities.Color()
            {
                Id = 1,
                Name = "Не указано",
                Description = "Не указано"
            };
            context.Colors.Add(color1);

            var color2 = new Entities.Color()
            {
                Id = 2,
                Name = "Чёрный",
                Description = "Тёмный цвет"
            };
            context.Colors.Add(color2);

            var color3 = new Entities.Color()
            {
                Id = 3,
                Name = "Серый",
                Description = "Тёмный цвет"
            };
            context.Colors.Add(color3);

            var color4 = new Entities.Color()
            {
                Id = 4,
                Name = "Белый",
                Description = "Белый цвет"
            };
            context.Colors.Add(color4);

            var color5 = new Entities.Color()
            {
                Id = 5,
                Name = "Рыжий",
                Description = "Оранжевый цвет"
            };
            context.Colors.Add(color5);

            context.SaveChanges();

            var petType1 = new Entities.PetType()
            {
                Id = 1,
                Name = "Не указано",
                Description = "Не указано",
                BreedId = breed1.Id
            };
            context.PetTypies.Add(petType1);

            var petType2 = new Entities.PetType()
            {
                Id = 2,
                Name = "Собака",
                Description = "Всю жизнь бегает за кошкой",
                BreedId = breed2.Id,
            };
            context.PetTypies.Add(petType2);

            var petType3 = new Entities.PetType()
            {
                Id = 3,
                Name = "Кошка",
                Description = "9 жизней",
                BreedId = breed5.Id,
            };
            context.PetTypies.Add(petType3);

            var petType4 = new Entities.PetType()
            {
                Id = 4,
                Name = "Попугай",
                Description = "Бешеный",
                BreedId = 1,
            };
            context.PetTypies.Add(petType4);

            var petType5 = new Entities.PetType()
            {
                Id = 5,
                Name = "Шиншила",
                Description = "Глупое создание",
                BreedId = 1,
            };
            context.PetTypies.Add(petType5);
                        
            context.SaveChanges();

            var city1 = new Entities.City()
            {
                Id = 1,
                Name = "Воронеж"
            };
            context.Cities.Add(city1);

            var city2 = new Entities.City()
            {
                Id = 2,
                Name = "Москва"
            };
            context.Cities.Add(city2);

            var city3 = new Entities.City()
            {
                Id = 3,
                Name = "Санкт-Петербург"
            };
            context.Cities.Add(city3);

            var city4 = new Entities.City()
            {
                Id = 4,
                Name = "Новосибирск"
            };
            context.Cities.Add(city4);

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
