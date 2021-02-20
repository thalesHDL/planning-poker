using Microsoft.Extensions.DependencyInjection;
using PlanningPokerServer.Data.Repository;

namespace PlanningPokerServer.Extension {
    public static class RepositoryExtension {
        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddTransient(typeof(IAsyncRepository<,>), typeof(AsyncRepository<,>));
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}