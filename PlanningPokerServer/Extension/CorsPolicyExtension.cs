using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace PlanningPokerServer.Extension {
    public static class CorsPolicyExtension {
        public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder App, IConfiguration Configuration) {
            App.UseCors(builder => {
                builder.WithOrigins(Configuration["CorsPolicy:Origin"])
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
            return App;
        }
    }
}