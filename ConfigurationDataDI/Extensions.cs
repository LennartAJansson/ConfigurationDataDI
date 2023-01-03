namespace HostedConsole2;

using ConfigurationDataDI;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class AppExtensions
{
    public static IServiceCollection AddAppSetup(this IServiceCollection services, Func<IConfiguration> getConfiguration)
    {
        IConfiguration config = getConfiguration?.Invoke() ?? throw new ArgumentNullException();
        _ = services.Configure<ConfigurationData>(settings => config.GetSection(ConfigurationData.SectionName).Bind(settings));

        _ = services.AddHostedService<Worker1>();

        return services;
    }

    public static IServiceCollection AddAppSetup(this IServiceCollection services, Action<ConfigurationData> configureCallback)
    {
        ConfigurationData config = new();
        configureCallback?.Invoke(config);
        _ = services.AddSingleton(config);

        _ = services.AddHostedService<Worker2>();

        return services;
    }
}
