using Microsoft.EntityFrameworkCore;
using PetProject.Db.Context.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Db.Context.Factories
{
    public class DbContextOptionFactory
    {
        public static DbContextOptions<MainDbContext> Create(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<MainDbContext>();
            Configure(connectionString).Invoke(builder);
            return builder.Options;
        }

        public static Action<DbContextOptionsBuilder> Configure(string connectionString)
        {
            return (builder) => builder.UseNpgsql(connectionString, opt =>
            {
                opt.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
            });
        }
    }
}
