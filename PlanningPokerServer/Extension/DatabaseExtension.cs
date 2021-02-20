using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlanningPokerServer.Data.Context;

namespace PlanningPokerServer.Extension {
    public static class DatabaseExtension {
        public static IServiceCollection AddDatabase(this IServiceCollection Services, IConfiguration Configuration) {
            Services.AddDbContext<ApplicationDatabaseContext>(config => config.UseNpgsql(Configuration["ConnectionString:Docker"]));
            return Services;
        }
    }
}