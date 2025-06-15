using Lab_2.API;
using Lab_2.API.Endpoints;
using Lab_2.Application;
using Lab_2.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var environment = builder.Environment;

builder.Services
            .AddConfigurations(configuration, environment)
            .AddInfrastructure(configuration)
            .AddApplication();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapCsvEndpoints();
app.MapEmployeeEndpoints();

app.Run();
