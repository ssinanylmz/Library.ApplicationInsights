using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;

namespace Library.ApplicationInsights.Extensions
{
    public static class ApplicationInsightsExtension
    {
        public static IServiceCollection AddCustomApplicationInsights(this IServiceCollection services)
        {

            // telemetry initializer
            services.AddSingleton<ITelemetryInitializer>(new TelemetryInitializer());

            return services;
        }
    }
}
