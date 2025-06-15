namespace Lab_2.API;

public static class DependencyInjection
{
    public static IServiceCollection AddConfigurations(
        this IServiceCollection services,
        ConfigurationManager configuration,
        IWebHostEnvironment environment)
    {
        configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
