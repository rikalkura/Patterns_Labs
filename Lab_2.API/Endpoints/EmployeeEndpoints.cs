using Lab_2.Application.Behaviors.Employee.Create;
using Lab_2.Application.Behaviors.Employee.Delete;
using Lab_2.Application.Behaviors.Employee.Get;
using Lab_2.Application.Behaviors.Employee.GetById;
using Lab_2.Application.Behaviors.Employee.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab_2.API.Endpoints;

public static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints(this WebApplication app)
    {
        var employeeEndpoints = app.MapGroup("/employees")
            .WithTags("Employees");

        employeeEndpoints.MapPost("/post-employee", async (
            CreateEmployeeCommand command, IMediator mediator) =>
        {
            await mediator.Send(command);

            return Results.Ok();
        });

        employeeEndpoints.MapGet("/get-employees", async (
            IMediator mediator) =>
        {
            var query = new GetEmployeesQuery();

            var employees = await mediator.Send(query);

            return Results.Ok(employees);
        });

        employeeEndpoints.MapGet("/get-employee/{id}", async(
            Guid id,
            IMediator mediator) =>
        {
            var query = new GetEmployeeByIdQuery(id);

            var employee = await mediator.Send(query);

            return Results.Ok(employee);
        });

        employeeEndpoints.MapDelete("/delete-employee/{id}", async(
            Guid id,
            IMediator mediator) =>
        {
            var command = new DeleteEmployeeCommand(id);

            await mediator.Send(command);

            return Results.Ok();
        });

        employeeEndpoints.MapPut("/update-employee/{id}", async(
            Guid id,
            UpdateEmployeeCommand command,
            IMediator mediator) =>
        {
            command.Id = id;

            await mediator.Send(command);

            return Results.Ok();
        });
    }
}
