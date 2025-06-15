using Lab_2.Application.Behaviors.Csv;
using MediatR;

namespace Lab_2.API.Endpoints;

public static class CsvEndpoints
{
    public static void MapCsvEndpoints(this WebApplication app)
    {
        var csvEndpoints = app.MapGroup("/csv")
            .WithTags("Csv");

        csvEndpoints.MapPost("/load-csv", async (
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data/employees.csv");

            if (!File.Exists(filePath))
                return Results.BadRequest("CSV file not found at root of API project.");

            var result = await mediator.Send(new LoadCsvToDbCommand(filePath), cancellationToken);

            return Results.Ok(new { inserted = result });
        });
    }
}
