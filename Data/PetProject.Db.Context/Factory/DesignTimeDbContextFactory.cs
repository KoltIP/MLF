using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PetProject.Db.Context.Context;

namespace PetProject.Db.Context.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
    {
        public MainDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.design.json")
                 .Build();

            var options = new DbContextOptionsBuilder<MainDbContext>()
                          .UseNpgsql(configuration.GetConnectionString("MainDbContext"),
                                opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
                           ).Options;

            return new MainDbContextFactory(options).Create();
        }
    }
}
