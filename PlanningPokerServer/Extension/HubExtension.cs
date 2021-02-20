using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlanningPokerServer.Core;

namespace PlanningPokerServer.Extension {
    public static class HubExtension {
        public static IServiceCollection AddHub(this IServiceCollection Services) {
            Services
                .AddSignalR(options => options.EnableDetailedErrors = true)
                .AddJsonProtocol(options => options.PayloadSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
            Services.AddSingleton<IGameManager, GameManager>();
            return Services;
        }
        public static IApplicationBuilder UseHub(this IApplicationBuilder App, IConfiguration Configuration) {
            App.UseEndpoints(endpoints => endpoints.MapHub<GameHub>(Configuration["Hub:NameSpace"]));
            return App;
        }
    }
}