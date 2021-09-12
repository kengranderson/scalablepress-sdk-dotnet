using Microsoft.Extensions.DependencyInjection;
using System;

namespace ScalablePress.API
{
    public static class Extensions
    {

        public static IServiceCollection AddScalablePressAPI(this IServiceCollection services, Action<ScalablePressAPIConfiguration> optionsConfig)
        {
            var options = new ScalablePressAPIConfiguration();
            optionsConfig(options);
            return services.AddSingleton(options);
        }
    }
}
