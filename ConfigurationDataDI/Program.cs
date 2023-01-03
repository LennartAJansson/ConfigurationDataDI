using ConfigurationDataDI;

using HostedConsole2;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => AddServices(context, services))
    .Build();

using (host)
{
    await host.StartAsync();

    await host.WaitForShutdownAsync();
}
void AddServices(HostBuilderContext context, IServiceCollection services)
{
    services.AddAppSetup(() => context.Configuration);
    services.AddAppSetup(config => context.Configuration.GetSection(ConfigurationData.SectionName).Bind(config));
}