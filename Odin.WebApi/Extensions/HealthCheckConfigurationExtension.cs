using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;

namespace Odin.WebApi.Extensions
{
    public static class HealthCheckConfigurationExtension
    {
        public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder application)
        {
            application.UseHealthChecks("/api/health", new HealthCheckOptions()
            {
                ResponseWriter = async (context, report) =>
                {
                    await context.Response.WriteAsync("OK");
                }
            });

            return application;
        }
    }
}
