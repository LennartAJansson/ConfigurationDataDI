namespace ConfigurationDataDI;

using Microsoft.Extensions.Logging;

using System.Threading;
using System.Threading.Tasks;

internal class Worker2 : BackgroundService
{
    private readonly ILogger<Worker2> logger;
    private readonly ConfigurationData config;
    public Worker2(ILogger<Worker2> logger, ConfigurationData config)
    {
        this.logger = logger;
        this.config = config;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation(config.Url);
        return Task.CompletedTask;
    }
}