﻿using AutoMapper;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.BreedServices.Models
{
    public class BreedModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }

    public class BreedModelProfile : Profile
    {
        public BreedModelProfile()
        {
            CreateMap<Breed, BreedModel>();
        }
    }
}
