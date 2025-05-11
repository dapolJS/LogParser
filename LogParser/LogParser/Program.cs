using LogParser.Interfaces;
using LogParser.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LogParser;

public static class Program
{
    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddTransient<ICsvLogReader, CsvLogReader>();
        services.AddTransient<ILogParserService, LogParserService>();
        services.AddTransient<IPropertyGetter, PropertyGetter>();
        return services.BuildServiceProvider();
    }

    public static void Main(string[] args)
    {
        var serviceProvider = ConfigureServices();

        var logParserService = serviceProvider.GetRequiredService<ILogParserService>();

        logParserService.Run();
    }
}   