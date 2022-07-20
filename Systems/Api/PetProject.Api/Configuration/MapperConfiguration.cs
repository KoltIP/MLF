using PetProject.Shared.Common.Helper;

namespace PetProject.Api.Configuration
{
    public static class MapperConfiguration
    {
        public static IServiceCollection AddAutoMappers(this IServiceCollection services)
        {
            AutoMappersRegisterHelper.Register(services);

            return services;
        }
    }
}
