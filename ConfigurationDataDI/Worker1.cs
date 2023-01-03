namespace HostedConsole2;

using ConfigurationDataDI;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System.Threading;
using System.Threading.Tasks;

internal class Worker1 : BackgroundService
{
    private readonly ConfigurationData config;
    private readonly ILogger<Worker1> logger;

    public Worker1(ILogger<Worker1> logger,IOptions<ConfigurationData> options)
    {
        config = options.Value;
        this.logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation(config.Url);
        return Task.CompletedTask;
    }
}
