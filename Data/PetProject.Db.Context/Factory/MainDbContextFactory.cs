using Microsoft.EntityFrameworkCore;
using PetProject.Db.Context.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Db.Context.Factories
{
    public class MainDbContextFactory
    {
        private readonly DbContextOptions<MainDbContext> options;

        public MainDbContextFactory(DbContextOptions<MainDbContext> options)
        {
            this.options = options;
        }

        public MainDbContext Create()
        {
            return new MainDbContext(options);
        }
    }
}
