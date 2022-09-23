using PetProject.EmailService;
using PetProject.RabbitMqService;
using PetProject.Settings;
using PetProject.Worker.TaskExecutors;

namespace PetProject.Worker
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services
                .AddSettings()
                .AddEmailSender()
                .AddRabbitMq()
                .AddSingleton<ITaskExecutor, TaskExecutor>();

            return services;
        }
    }
}
