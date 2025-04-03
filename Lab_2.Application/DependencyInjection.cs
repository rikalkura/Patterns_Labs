using Lab_2.Application.Services.Abstractions;
using Lab_2.Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Lab_2.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(c =>
            c.RegisterServicesFromAssembly(assembly));

        services.AddScoped<ICsvReaderService, CsvReaderService>();

        return services;
    }
}
